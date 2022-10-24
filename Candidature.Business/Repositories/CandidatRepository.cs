using Candidature.Business.Interfaces;
using Candidature.Data.Contexts;
using Candidature.Data.Models;
using Candidature.Module.Helper;
using Candidature.Module.Modules;
using Candidature.Module.Result;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidature.Business.Repositories
{
	public class CandidatRepository : BaseRepository, ICandidat
	{
		private readonly IHostingEnvironment hosting;
		public CandidatRepository(CandidatureContext context, IHostingEnvironment hosting) : base(context)
		{
			this.hosting = hosting;
		}

		public async Task<RESTServiceResponse<bool>> Add(CandidatModule model)
		{
			try
			{


				Candidat candidat = new Candidat();
				candidat.Nom = model.Nom;
				candidat.Prenom = model.Prenom;
				candidat.Email = model.Email;
				candidat.Telephone = model.Telephone;
				candidat.NbrAnneesDexperience = model.NbrAnneesDexperience;
				candidat.DernierEmployeur = model.DernierEmployeur;
				candidat.RefNiveauEtudeId = model.RefNiveauEtudeId;






				//if (model.File != null)
				//{
				//    var bytesFile = await GetBytes(model.File);
				//    candidat.File = bytesFile;
				//}


				if (model.File != null)
				{
					var pathUrl = Path.GetFileName(Path.Combine(hosting.WebRootPath, $"File/{candidat.Prenom + "-" + candidat.Nom }"));
					var pathname = candidat.Prenom + "-" + candidat.Nom + Path.GetExtension(model.File.FileName);
					var fullPathe = Path.Combine(pathUrl, pathname);
					candidat.Path = fullPathe;
				}

				_context.Candidats.Add(candidat);

				await _context.SaveChangesAsync();

				string filename = string.Empty;
				if (model.File != null)
				{
					var fichier = Path.Combine(hosting.WebRootPath, $"File/{candidat.Prenom + "-" + candidat.Nom}");
					if (!Directory.Exists(fichier)) Directory.CreateDirectory(fichier);
					filename = candidat.Prenom + "-" + candidat.Nom + Path.GetExtension(model.File.FileName);
					var fullPath = Path.Combine(fichier, filename);
					model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
				}




				return new RESTServiceResponse<bool>(true, "success", true);
			}
			catch (Exception ex)
			{
				return new RESTServiceResponse<bool>(false, ex.Message);
			}
		}

		public async Task<RESTServiceResponse<bool>> Delete(CandidatModule model)
		{

			try
			{
				var result = await _context.Candidats
					.Where(w => w.Id == model.Id)
					.FirstOrDefaultAsync();

				if (result != null)
				{
					_context.Candidats.Remove(result);
				}
				if (await _context.SaveChangesAsync() > 0)
					return new RESTServiceResponse<bool>(true, "success", true);

				return new RESTServiceResponse<bool>(false, "failed");
			}
			catch (Exception ex)
			{
				return new RESTServiceResponse<bool>(false, ex.Message);
			}
		}

		public async Task<RESTServiceResponse<List<CandidatModule>>> Get(string Keyword)
		{
			var query =  _context.Candidats
					.Include(i => i.RefNiveauEtude)
					.AsQueryable();

			if (!string.IsNullOrEmpty(Keyword))
			{
				Keyword = Keyword.ToLower();
				query = query.Where(w =>
					   (w.Nom ?? "").ToLower().Contains(Keyword) ||
					   (w.Prenom ?? "").ToLower().Contains(Keyword) ||
					   (w.Email ?? "").ToLower().Contains(Keyword) ||
					   (w.Telephone ?? "").ToLower().Contains(Keyword));
			}

			var result = query
				  .Select(s => new CandidatModule
				  {
					  Id = s.Id,
					  Nom = s.Nom,
					  Prenom = s.Prenom,
					  Email = s.Email,
					  Telephone = s.Telephone,
					  NbrAnneesDexperience = s.NbrAnneesDexperience,
					  DernierEmployeur = s.DernierEmployeur,
					  Path = s.Path,
					  RefNiveauEtude = s.RefNiveauEtude.Name

				  }).ToList();
			return new RESTServiceResponse<List<CandidatModule>>(true, "success", result);
		}
	}
}
