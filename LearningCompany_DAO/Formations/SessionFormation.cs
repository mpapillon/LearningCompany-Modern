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
        [Display(Name = "Formation")]
        public int FormationID { get; set; }
        public virtual Formation Formation { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de début")]
        public DateTime? DateDebut { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de fin")]
        public DateTime? DateFin { get; set; }

        [Required]
        [Display(Name = "Intervenant externieur ?")]
        public bool Intervenant { get; set; }

        [Display(Name = "Formateur")]
        public int FormateurID { get; set; }
        public virtual Formateur Formateur { get; set; }

        [Required]
        [Display(Name = "Commercial")]
        public int CommercialID { get; set; }
        public virtual Commercial Commercial { get; set; }

        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
