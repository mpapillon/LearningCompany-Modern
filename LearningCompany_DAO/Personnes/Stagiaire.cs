using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    [DataContract(Namespace="")]
    public class Stagiaire
    {
        // EF CodeFirst reconnaît les clefs primaires quand un attribut se termine par ID
        [DataMember]
        public int StagiaireID { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string Nom { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string Prenom { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        [Index(IsUnique = true)]
        public string Courriel { get; set; }

        [Required]
        public int CiviliteID { get; set; }
        [DataMember]
        public virtual Civilite Civilite { get; set; }

        [DataMember]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }

        public string NomComplet
        {
            get { return Nom + " " + Prenom; }
        }
    }
}
