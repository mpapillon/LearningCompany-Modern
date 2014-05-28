using LearningCompany_WinRT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearningCompany_WinRT.SampleData
{
    public class FormateurSample
    {
        public static IEnumerable<Formateur> Items
        {
            get
            {
                return new List<Formateur>
                {
                    new Formateur { Nom = "RAVAILLE", Prenom = "James", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "jravaille@worldCompany.fr", Telephone = "0270704401", IntervenantExterieur = false, Infos = "Spécialisé en Biologie moléculaire" },
                    new Formateur { Nom = "BERTIN", Prenom = "Dominique", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "dbertin@worldCompany.fr", Telephone = "0270704402", IntervenantExterieur = false, Infos = "Spécialisé en Pharmacie" },
                    new Formateur { Nom = "LONGUET", Prenom = "Alain", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "alonguet@worldCompany.fr", Telephone = "0270704403", IntervenantExterieur = false, Infos = "Spécialisé en Pharmacie" },
                    new Formateur { Nom = "AGOSTINO", Prenom = "Michelle", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "magostino@worldCompany.fr", Telephone = "0270704404", IntervenantExterieur = false, Infos = "Spécialisé en Chimie" },
                    new Formateur { Nom = "DUVERT", Prenom = "Jean-Louis", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "jlduvert@worldCompany.fr", Telephone = "0270704405", IntervenantExterieur = false, Infos = "Spécialisé en Droit pharmaceutique" },
                    new Formateur { Nom = "RIVET", Prenom = "Alexandre", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "arivet@worldCompany.fr", Telephone = "0270704406", IntervenantExterieur = false, Infos = "Spécialisé en Informatique" },
                    new Formateur { Nom = "VERSAULT", Prenom = "Pierre", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "pversault@worldCompany.fr", Telephone = "0270704407", IntervenantExterieur = false, Infos = "Spécialisé Informatique" },
                    new Formateur { Nom = "VADORT", Prenom = "François", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "fvadort@worldCompany.fr", Telephone = "0270704408", IntervenantExterieur = false, Infos = "Spécialisé en Management unité commerciale" },
                    new Formateur { Nom = "DANNEZ", Prenom = "Pierre", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "pdannez@worldCompany.fr", Telephone = "0270704409", IntervenantExterieur = false, Infos = "Spécialisé en relations clients" },
                    new Formateur { Nom = "GADET", Prenom = "Julie", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "jdadet@worldCompany.fr", Telephone = "0270704410", IntervenantExterieur = false, Infos = "Spécialisé en Droit public" },
                    new Formateur { Nom = "DOLLON", Prenom = "Julien", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "jdollon@worldCompany.fr", Telephone = "0270704411", IntervenantExterieur = false, Infos = "Assure des formations sur Microsoft Office" },
                    new Formateur { Nom = "HELIS", Prenom = "Frank", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "fhelis@worldCompany.fr", Telephone = "0270704412", IntervenantExterieur = false, Infos = "Formateur sur les navigateurs Internet" },
                    new Formateur { Nom = "REIS", Prenom = "Luis", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "lreis@worldCompany.fr", Telephone = "0270704413", IntervenantExterieur = false, Infos = "Assure des formations sur les normes du marché pharmaceutique" },
                    new Formateur { Nom = "RUSKOV", Prenom = "Elise", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "eruskov@worldCompany.fr", Telephone = "0683286446", IntervenantExterieur = true, Infos = "Enseigne les bases sur les architectures informatiques" },
                    new Formateur { Nom = "CADET", Prenom = "Nathalie", UrlPhoto = "ms-appx:///SampleData/Portrait.jpg", Courriel = "ncadet@worldCompany.fr", Telephone = "0637624657", IntervenantExterieur = true, Infos = "Dispense les formations sur les usages des nouvelles molécules" }
                };
            }
        }
    }
}
