using LearningCompany_WinRT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearningCompany_WinRT.SampleData
{
    public class FormateursSample
    {
        private List<Formateur> _formateurs;
        public List<Formateur> Formateurs 
        {
            get { return _formateurs; }
        }

        public FormateursSample()
        {
            _formateurs = new List<Formateur>
            {
                new Formateur { Nom = "RAVAILLE", Prenom = "James", UrlPhoto = "portrait.png", Courriel = "jravaille@worldCompany.fr", Telephone = "0270704401", IntervenantExterieur = false, Infos = "Spécialisé en Biologie moléculaire" },
                new Formateur { Nom = "BERTIN", Prenom = "Dominique", UrlPhoto = "portrait.png", Courriel = "dbertin@worldCompany.fr", Telephone = "0270704402", IntervenantExterieur = false, Infos = "Spécialisé en Pharmacie" },
                new Formateur { Nom = "LONGUET", Prenom = "Alain", UrlPhoto = "portrait.png", Courriel = "alonguet@worldCompany.fr", Telephone = "0270704403", IntervenantExterieur = false, Infos = "Spécialisé en Pharmacie" },
                new Formateur { Nom = "AGOSTINO", Prenom = "Michelle", UrlPhoto = "portrait.png", Courriel = "magostino@worldCompany.fr", Telephone = "0270704404", IntervenantExterieur = false, Infos = "Spécialisé en Chimie" },
                new Formateur { Nom = "DUVERT", Prenom = "Jean-Louis", UrlPhoto = "portrait.png", Courriel = "jlduvert@worldCompany.fr", Telephone = "0270704405", IntervenantExterieur = false, Infos = "Spécialisé en Droit pharmaceutique" },
                new Formateur { Nom = "RIVET", Prenom = "Alexandre", UrlPhoto = "portrait.png", Courriel = "arivet@worldCompany.fr", Telephone = "0270704406", IntervenantExterieur = false, Infos = "Spécialisé en Informatique" },
                new Formateur { Nom = "VERSAULT", Prenom = "Pierre", UrlPhoto = "portrait.png", Courriel = "pversault@worldCompany.fr", Telephone = "0270704407", IntervenantExterieur = false, Infos = "Spécialisé Informatique" },
                new Formateur { Nom = "VADORT", Prenom = "François", UrlPhoto = "portrait.png", Courriel = "fvadort@worldCompany.fr", Telephone = "0270704408", IntervenantExterieur = false, Infos = "Spécialisé en Management unité commerciale" },
                new Formateur { Nom = "DANNEZ", Prenom = "Pierre", UrlPhoto = "portrait.png", Courriel = "pdannez@worldCompany.fr", Telephone = "0270704409", IntervenantExterieur = false, Infos = "Spécialisé en relations clients" },
                new Formateur { Nom = "GADET", Prenom = "Julie", UrlPhoto = "portrait.png", Courriel = "jdadet@worldCompany.fr", Telephone = "0270704410", IntervenantExterieur = false, Infos = "Spécialisé en Droit public" },
                new Formateur { Nom = "DOLLON", Prenom = "Julien", UrlPhoto = "portrait.png", Courriel = "jdollon@worldCompany.fr", Telephone = "0270704411", IntervenantExterieur = false, Infos = "Assure des formations sur Microsoft Office" },
                new Formateur { Nom = "HELIS", Prenom = "Frank", UrlPhoto = "portrait.png", Courriel = "fhelis@worldCompany.fr", Telephone = "0270704412", IntervenantExterieur = false, Infos = "Formateur sur les navigateurs Internet" },
                new Formateur { Nom = "REIS", Prenom = "Luis", UrlPhoto = "portrait.png", Courriel = "lreis@worldCompany.fr", Telephone = "0270704413", IntervenantExterieur = false, Infos = "Assure des formations sur les normes du marché pharmaceutique" },
                new Formateur { Nom = "RUSKOV", Prenom = "Elise", UrlPhoto = "portrait.png", Courriel = "eruskov@worldCompany.fr", Telephone = "0683286446", IntervenantExterieur = true, Infos = "Enseigne les bases sur les architectures informatiques" },
                new Formateur { Nom = "CADET", Prenom = "Nathalie", UrlPhoto = "portrait.png", Courriel = "ncadet@worldCompany.fr", Telephone = "0637624657", IntervenantExterieur = true, Infos = "Dispense les formations sur les usages des nouvelles molécules" }
            };
        }

        public ICollection<Formateur> FormateursInternes
        {
            get
            {
                return _formateurs.Where(f => f.IntervenantExterieur == false).ToList();
            }
        }

        public ICollection<Formateur> FormateursExternes
        {
            get
            {
                return _formateurs.Where(f => f.IntervenantExterieur == true).ToList();
            }
        }
    }
}
