using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    [Table("Commerciaux")]
    public class Commercial
    {
        #region Attributes
        public int CommercialID { get; set; }

        [MaxLength(50), Required]
        public string NomUtilisateur { get; set; }

        [MaxLength(50), Required]
        public string MotDePasse { get; set; }

        [MaxLength(50), Required]
        public string Nom { get; set; }

        [MaxLength(50), Required]
        public string Prenom { get; set; }

        [MaxLength(50), Required]
        [Index(IsUnique = true)]
        public string Courriel { get; set; }

        [Required]
        public int CiviliteID { get; set; }
        public virtual Civilite Civilite { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }
        #endregion

        #region Methodes

        public static Commercial GetByAuthentication(string aUsername, string aPassword)
        {
            using(var db = new LearningCompanyContext())
            {
                return (from oCommcecial in db.Commerciaux
                        where oCommcecial.NomUtilisateur == aUsername
                        && oCommcecial.MotDePasse == aPassword
                        select oCommcecial).FirstOrDefault();
            }
        }

        #endregion
    }
}
