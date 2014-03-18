using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class FormationElearning : Formation
    {
        [Required]
        public string Url { get; set; }
    }
}
