using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany_WP.AccesCommerciaux
{
    public partial class Formateur
    {
        public string NomComplet 
        { 
            get
            {
                return this.Nom + " " + this.Prenom;
            } 
        }
    }
}
