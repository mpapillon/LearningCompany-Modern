using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class Formateur
    {
        public int FormateurID { get; set; }

        [MaxLength(50), Required]
        public string Nom { get; set; }

        [MaxLength(50), Required]
        public string Prenom { get; set; }

        public string UrlPhoto { get; set; }

        [MaxLength(50), Required]
        public string Courriel { get; set; }

        [MaxLength(10), Required]
        public string Telephone { get; set; }

        [Required]
        public bool IntervenantExterieur { get; set; }

        [Required]
        public string Infos { get; set; }

        [Required]
        public int CiviliteID { get; set; }
        public virtual Civilite Civilite { get; set; }

        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }
    }
}
