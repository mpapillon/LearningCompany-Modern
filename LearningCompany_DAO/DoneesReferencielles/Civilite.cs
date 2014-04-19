using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    [DataContract(Namespace = "")]
    public class Civilite
    {
        [DataMember]
        public int CiviliteID { get; set; }

        [DataMember]
        [MaxLength(5), Required]
        public string LibelleCourt { get; set; }

        [DataMember]
        [MaxLength(50), Required]
        public string LibelleLong { get; set; }

        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
        public virtual ICollection<Commercial> Commerciaux { get; set; }
        public virtual ICollection<Formateur> Formateurs { get; set; }
    }
}
