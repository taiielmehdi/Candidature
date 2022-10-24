using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidature.Module.Modules
{
    public class CandidatModule
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? NbrAnneesDexperience { get; set; }
        public string? DernierEmployeur { get; set; }

        public string? RefNiveauEtude { get; set; }
        public string? Path { get; set; }

        public IFormFile File { get; set; }
        public int? RefNiveauEtudeId { get; set; }

    }
}
