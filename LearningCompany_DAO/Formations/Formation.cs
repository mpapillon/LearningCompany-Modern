using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class Formation
    {
        #region Attributes
        public int FormationID { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Référence")]
        public string Reference { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Libellé")]
        public string Libelle { get; set; }

        [Required]
        [Display(Name = "Durée")]
        public Int16 NombreJours { get; set; }

        [Required]
        [Display(Name = "Prix (en €)")]
        public Decimal Prix { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Thème")]
        public int ThemeID { get; set; }
        public virtual Theme Theme { get; set; }

        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }
        public virtual ICollection<Formateur> Formateurs { get; set; }
        public virtual ICollection<DemandeClient> DemandesClients { get; set; }

        public string ShortDescription
        {
            get
            {
                return this.Reference + " - " + this.Libelle;
            }
        }

        #endregion
    }
}
