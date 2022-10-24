using System;
using System.Collections.Generic;

namespace Candidature.Data.Models
{
    public partial class RefNiveauEtude
    {
        public RefNiveauEtude()
        {
            Candidats = new HashSet<Candidat>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Candidat> Candidats { get; set; }
    }
}
