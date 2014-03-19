using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class Client
    {
        public int ClientID { get; set; }

        [MaxLength(50), Required]
        [Index(IsUnique = true)]
        public string Reference { get; set; }

        [MaxLength(50), Required]
        public string RaisonSociale { get; set; }

        [Required]
        public string Adresse { get; set; }

        [MaxLength(5), Required]
        public string CodePostal { get; set; }

        [MaxLength(100), Required]
        public string Ville { get; set; }

        [MaxLength(10), Required]
        public string Telephone { get; set; }

        [MaxLength(50), Required]
        public string Courriel { get; set; }

        [Required]
        public string UrlSite { get; set; }

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
