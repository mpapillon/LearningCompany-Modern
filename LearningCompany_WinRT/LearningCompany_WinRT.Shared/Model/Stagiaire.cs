using System;
using System.Collections.Generic;
using System.Text;

namespace LearningCompany_WinRT.Model
{
    public class Stagiaire
    {
        public string odatametadata { get; set; }
        public int StagiaireID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Courriel { get; set; }
        public int CiviliteID { get; set; }
        public int ClientID { get; set; }
    }
}
