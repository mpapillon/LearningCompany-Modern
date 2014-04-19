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
    public class Client
    {
        [DataMember]
        public int ClientID { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        [Index(IsUnique = true)]
        public string Reference { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string RaisonSociale { get; set; }

        [DataMember]
        [Required]
        public string Adresse { get; set; }

        [DataMember]
        [MaxLength(5), Required]
        public string CodePostal { get; set; }

        [DataMember]
        [MaxLength(100), Required]
        public string Ville { get; set; }

        [DataMember]
        [MaxLength(10), Required]
        public string Telephone { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string Courriel { get; set; }

        [DataMember]
        [Required]
        public string UrlSite { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string MotDePasse { get; set; }

        [Required]
        public int SecteurActiviteID { get; set; }
        public virtual SecteurActivite SecteurActivite { get; set; }

        [Required]
        public int CommercialID { get; set; }
        public virtual Commercial Commercial { get; set; }

        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
        public virtual ICollection<DemandeClient> DemandesClients { get; set; }
    }
}
