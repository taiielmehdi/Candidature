using System;
using System.Collections.Generic;

namespace Candidature.Data.Models
{
    public partial class Candidat
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public string? NbrAnneesDexperience { get; set; }
        public string? DernierEmployeur { get; set; }
        public byte[]? File { get; set; }
        public string? Path { get; set; }
        public int? RefNiveauEtudeId { get; set; }

        public virtual RefNiveauEtude? RefNiveauEtude { get; set; }
    }
}
