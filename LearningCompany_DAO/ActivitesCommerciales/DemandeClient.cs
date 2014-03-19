using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LearningCompany.Entities
{
    public class DemandeClient
    {
        [Key]
        [Column(Order = 1)] 
        public int DemandeClientID { get; set; }

        [Key]
        [Column(Order = 2), Index]
        public int FormationID { get; set; }

        [Required]
        public DateTime? DateDemande { get; set; }

        public DateTime? DateTraitement { get; set; }

        [Required]
        [Index]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public virtual Formateur Formation { get; set; }
    }
}
