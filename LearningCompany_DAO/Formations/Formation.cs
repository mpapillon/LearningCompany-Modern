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
        public int FormationID { get; set; }

        [MaxLength(50), Required]
        public string Reference { get; set; }

        [MaxLength(50), Required]
        public string Libelle { get; set; }

        [Required]
        public Int16 NombreJours { get; set; }

        [Required]
        public Decimal Prix { get; set; }

        [Required]
        public string Decription { get; set; }

        [Required]
        public int ThemeID { get; set; }
        public virtual Theme Theme { get; set; }

        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }
        public virtual ICollection<Formateur> Formateurs { get; set; }
        public virtual ICollection<DemandeClient> DemandesClients { get; set; }
    }
}
