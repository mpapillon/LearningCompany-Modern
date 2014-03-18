using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class FormationPresentielle : Formation
    {
        [MaxLength(50), Required]
        public string Lieu { get; set; }
    }
}
