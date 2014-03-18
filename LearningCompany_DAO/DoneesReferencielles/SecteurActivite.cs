using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class SecteurActivite
    {
        public int SecteurActiviteID { get; set; }

        [MaxLength(50), Required]
        public string Libelle { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
