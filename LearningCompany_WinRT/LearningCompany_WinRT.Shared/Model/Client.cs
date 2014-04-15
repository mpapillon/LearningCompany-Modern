using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.Model
{
    public class Client
    {
        public string odatametadata { get; set; }
        public int ClientID { get; set; }
        public string Reference { get; set; }
        public string RaisonSociale { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }
        public string UrlSite { get; set; }
        public string MotDePasse { get; set; }
        public int SecteurActiviteID { get; set; }
        public int CommercialID { get; set; }
    }

}
