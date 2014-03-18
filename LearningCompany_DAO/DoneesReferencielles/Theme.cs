using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class Theme
    {
        public int ThemeID { get; set; }

        [MaxLength(50), Required]
        public string Libelle { get; set; }
    }
}
