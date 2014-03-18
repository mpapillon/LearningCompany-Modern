using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class SessionFormation
    {
        [Key]
        [Column(Order = 1)] 
        public int SessionFormationID { get; set; }

        [Key]
        [Column(Order = 2)] 
        public int FormationID { get; set; }

        [Required]
        public DateTime? DateDebut { get; set; }

        [Required]
        public DateTime? DateFin { get; set; }

        [Required]
        public bool Intervenant { get; set; }

        public virtual Formation Formation { get; set; }

        [Required]
        public int FormateurID { get; set; }
        public virtual Formateur Formateur { get; set; }

        [Required]
        public int CommercialID { get; set; }
        public virtual Commercial Commercial { get; set; }

        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
