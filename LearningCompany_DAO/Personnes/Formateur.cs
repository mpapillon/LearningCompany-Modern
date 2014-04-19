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
    [DataContract(Namespace = "")]
    public class Formateur
    {
        [DataMember]
        public int FormateurID { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string Nom { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string Prenom { get; set; }

        [DataMember]
        public string UrlPhoto { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        [Index(IsUnique = true)]
        public string Courriel { get; set; }

        [DataMember]
        [MaxLength(10), Required]
        public string Telephone { get; set; }

        [DataMember]
        [Required]
        public bool IntervenantExterieur { get; set; }

        [DataMember]
        [Required]
        public string Infos { get; set; }

        [Required]
        public int CiviliteID { get; set; }
        [DataMember]
        public virtual Civilite Civilite { get; set; }

        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }
        public virtual ICollection<Formation> Formations { get; set; }

        public string NomComplet
        {
            get { return Nom + " " + Prenom; }
        }
    }
}
