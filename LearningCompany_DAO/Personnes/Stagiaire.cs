using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class Stagiaire
    {
        // EF CodeFirst reconnaît les clefs primaires quand un attribut se termine par ID
        public int StagiaireID { get; set; }

        [MaxLength(50), Required]
        public string Nom { get; set; }

        [MaxLength(50), Required]
        public string Prenom { get; set; }

        [MaxLength(50), Required] 
        public string Courriel { get; set; }

        [Required]
        public int CiviliteID { get; set; }
        public virtual Civilite Civilite { get; set; }

        [Required]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }
    }
}
