using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.Model
{
    public class Formateur
    {
        public string odatametadata { get; set; }
        public int FormateurID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string UrlPhoto { get; set; }
        public string Courriel { get; set; }
        public string Telephone { get; set; }
        public bool IntervenantExterieur { get; set; }
        public string Infos { get; set; }
        public int CiviliteID { get; set; }
    }
}
