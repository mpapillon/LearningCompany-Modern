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
        public int DemandeClientID { get; set; }

        [Index]
        public int FormationID { get; set; }

        [Required]
        public DateTime? DateDemande { get; set; }

        public DateTime? DateTraitement { get; set; }

        [Required]
        [Index]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public virtual Formation Formation { get; set; }
    }
}
