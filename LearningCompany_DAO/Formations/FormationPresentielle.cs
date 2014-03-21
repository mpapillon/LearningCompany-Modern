using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class FormationPresentielle : Formation
    {
        [MaxLength(50), Required]
        public string Lieu { get; set; }

        public FormationPresentielle(){}

        public FormationPresentielle(Formation formation)
        {
            this.FormationID = formation.FormationID;
            this.Reference = formation.Reference;
            this.Libelle = formation.Libelle;
            this.NombreJours = formation.NombreJours;
            this.Prix = formation.Prix;
            this.Description = formation.Description;
            this.ThemeID = formation.ThemeID;
        }
    }
}
