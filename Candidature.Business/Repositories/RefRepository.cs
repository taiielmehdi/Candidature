using Candidature.Business.Interfaces;
using Candidature.Data.Contexts;
using Candidature.Module.Helper;
using Candidature.Module.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidature.Business.Repositories
{
    public class RefRepository : BaseRepository ,IRef
    {
        public RefRepository(CandidatureContext context) : base(context)
        {

        }
        public async Task<RESTServiceResponse<List<REFResult>>> RefNiveauEtude()
        {
            try
            {
                var result = await _context.RefNiveauEtudes.Select(s => new REFResult
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToListAsync();

                return new RESTServiceResponse<List<REFResult>>(true, "success", result);
            }
            catch (Exception ex)
            {
                return new RESTServiceResponse<List<REFResult>>(false, ex.Message);
            }
        }
    }
}
