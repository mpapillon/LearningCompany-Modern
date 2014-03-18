using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class Civilite
    {
        public int CiviliteID { get; set; }

        [MaxLength(5), Required]
        public string LibelleCourt { get; set; }

        [MaxLength(50), Required]
        public string LibelleLong { get; set; }

        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
        public virtual ICollection<Commercial> Commerciaux { get; set; }
        public virtual ICollection<Formateur> Formateurs { get; set; }
    }
}
