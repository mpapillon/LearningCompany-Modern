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
        [Display(Name = "Nom d'utilisateur")]
        public string NomUtilisateur { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Mot de passe")]
        public string MotDePasse { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [MaxLength(50), Required]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; }

        [MaxLength(50), Required]
        [Index(IsUnique = true)]
        [Display(Name = "Courriel")]
        public string Courriel { get; set; }

        [Required]
        [Display(Name = "Civilité")]
        public int CiviliteID { get; set; }
        public virtual Civilite Civilite { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<SessionFormation> SessionsFormations { get; set; }


        public string NomComplet
        {
            get { return Nom + " " + Prenom; }   
        }
        
        #endregion

        #region Methodes

        public Commercial() { }

        public Commercial(string unNom, string unPrenom, string unNomUtilisateur, 
            string unMotDePasse, string unCourriel, Civilite uneCivilite)
        {
            this.Nom = unNom;
            this.Prenom = unPrenom;
            this.NomUtilisateur = unNomUtilisateur;
            this.MotDePasse = unMotDePasse;
            this.Courriel = unCourriel;
            this.Civilite = uneCivilite;
        }

        public static Commercial FindByAuthentication(string aUsername, string aPassword)
        {
            using(var db = new LearningCompanyContext())
            {
                return (from oCommcecial in db.Commerciaux
                        where oCommcecial.NomUtilisateur == aUsername
                        && oCommcecial.MotDePasse == aPassword
                        select oCommcecial).FirstOrDefault();
            }
        }

        public int GetNombreDemandesClientsEnAttente()
        {
            using (var db = new LearningCompanyContext())
            {
                return (from oDemandeClient in db.DemandesClients
                        where oDemandeClient.Client.Commercial.CommercialID == this.CommercialID
                            && oDemandeClient.DateTraitement == null
                        select oDemandeClient).Count();
            }
        }

        public List<DemandeClient> GetListeDemandesClientsEnAttente()
        {
            using (var db = new LearningCompanyContext())
            {
                return (from oDemandeClient in db.DemandesClients
                        where oDemandeClient.Client.Commercial.CommercialID == this.CommercialID
                            && oDemandeClient.DateTraitement == null
                        select oDemandeClient).ToList();
            }
        }

        #endregion
    }
}
