﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCompany.Entities
{
    public class LearningCompanyInitializer : System.Data.Entity.DropCreateDatabaseAlways<LearningCompanyContext>
    {
        protected override void Seed(LearningCompanyContext context)
        {
            #region Themes
            var themes = new List<Theme>
            {
                new Theme { Libelle = "Microsoft Office" },
                new Theme { Libelle = "Internet Explorer" },
                new Theme { Libelle = "Mozilla FireFox" },
                new Theme { Libelle = "Utilisation du PC portable sous Windows" },
                new Theme { Libelle = "Transmission et Sauvegardes des données" },
                new Theme { Libelle = "Biologie moléculaire" },
                new Theme { Libelle = "Interactions médicamenteuses" },
                new Theme { Libelle = "Nouvelles molécules pharmaceutiques" },
                new Theme { Libelle = "Gestion de la relation médecin" },
                new Theme { Libelle = "Autorisations de mise sur le marché et sécurité" }
            };

            themes.ForEach(t => context.Themes.Add(t));
            context.SaveChanges();
            #endregion

            #region Secteurs d'activités
            var secteursActivite = new List<SecteurActivite>
            {
                new SecteurActivite { Libelle = "Réseau de Distribution" },
                new SecteurActivite { Libelle = "Fabrication pharmaceutiques" },
                new SecteurActivite { Libelle = "Formation" },
                new SecteurActivite { Libelle = "Recherches et développement" },
                new SecteurActivite { Libelle = "Contrôles qualité" },
                new SecteurActivite { Libelle = "Posologie et éditique" },
                new SecteurActivite { Libelle = "Relations ministérielles" },
                new SecteurActivite { Libelle = "Marketing" },
                new SecteurActivite { Libelle = "Relations médecins" },
                new SecteurActivite { Libelle = "Investissement et Finances" },
            };

            secteursActivite.ForEach(sa => context.SecteursActivites.Add(sa));
            context.SaveChanges();
            #endregion

            #region Civilites
            var civilites = new List<Civilite>
            {
                new Civilite { LibelleCourt = "Mlle", LibelleLong = "Mademoiselle" },
                new Civilite { LibelleCourt = "Mme", LibelleLong = "Madame" },
                new Civilite { LibelleCourt = "M.", LibelleLong = "Monsieur" }
            };

            civilites.ForEach(c => context.Civilites.Add(c));
            context.SaveChanges();
            #endregion

            #region Formateurs
            var formateurs = new List<Formateur>
            {
                new Formateur { Nom = "RAVAILLE", Prenom = "James", UrlPhoto = "Content/portraits/jravaille.jpg", Courriel = "jravaille@worldCompany.fr", Telephone = "0270704401", IntervenantExterieur = false, Infos = "Spécialisé en Biologie moléculaire", Civilite = civilites[2] },
                new Formateur { Nom = "BERTIN", Prenom = "Dominique", UrlPhoto = "Content/portraits/dbertin.jpg", Courriel = "dbertin@worldCompany.fr", Telephone = "0270704402", IntervenantExterieur = false, Infos = "Spécialisé en Pharmacie", Civilite = civilites[2] },
                new Formateur { Nom = "LONGUET", Prenom = "Alain", UrlPhoto = "Content/portraits/alonguet.jpg", Courriel = "alonguet@worldCompany.fr", Telephone = "0270704403", IntervenantExterieur = false, Infos = "Spécialisé en Pharmacie", Civilite = civilites[2] },
                new Formateur { Nom = "AGOSTINO", Prenom = "Michelle", UrlPhoto = "Content/portraits/magostino.jpg", Courriel = "magostino@worldCompany.fr", Telephone = "0270704404", IntervenantExterieur = false, Infos = "Spécialisé en Chimie", Civilite = civilites[1] },
                new Formateur { Nom = "DUVERT", Prenom = "Jean-Louis", UrlPhoto = "Content/portraits/jlduvert.jpg", Courriel = "jlduvert@worldCompany.fr", Telephone = "0270704405", IntervenantExterieur = false, Infos = "Spécialisé en Droit pharmaceutique", Civilite = civilites[2] },
                new Formateur { Nom = "RIVET", Prenom = "Alexandre", UrlPhoto = "Content/portraits/arivet.jpg", Courriel = "arivet@worldCompany.fr", Telephone = "0270704406", IntervenantExterieur = false, Infos = "Spécialisé en Informatique", Civilite = civilites[2] },
                new Formateur { Nom = "VERSAULT", Prenom = "Pierre", UrlPhoto = "Content/portraits/pversault.jpg", Courriel = "pversault@worldCompany.fr", Telephone = "0270704407", IntervenantExterieur = false, Infos = "Spécialisé Informatique", Civilite = civilites[2] },
                new Formateur { Nom = "VADORT", Prenom = "François", UrlPhoto = "Content/portraits/fvadort.jpg", Courriel = "fvadort@worldCompany.fr", Telephone = "0270704408", IntervenantExterieur = false, Infos = "Spécialisé en Management unité commerciale", Civilite = civilites[2] },
                new Formateur { Nom = "DANNEZ", Prenom = "Pierre", UrlPhoto = "Content/portraits/pdannez.jpg", Courriel = "pdannez@worldCompany.fr", Telephone = "0270704409", IntervenantExterieur = false, Infos = "Spécialisé en relations clients", Civilite = civilites[2] },
                new Formateur { Nom = "GADET", Prenom = "Julie", UrlPhoto = "Content/portraits/jdadet.jpg", Courriel = "jdadet@worldCompany.fr", Telephone = "0270704410", IntervenantExterieur = false, Infos = "Spécialisé en Droit public", Civilite = civilites[1] },
                new Formateur { Nom = "DOLLON", Prenom = "Julien", UrlPhoto = "Content/portraits/jdollon.jpg", Courriel = "jdollon@worldCompany.fr", Telephone = "0270704411", IntervenantExterieur = false, Infos = "Assure des formations sur Microsoft Office", Civilite = civilites[2] },
                new Formateur { Nom = "HELIS", Prenom = "Frank", UrlPhoto = "Content/portraits/fhelis.jpg", Courriel = "fhelis@worldCompany.fr", Telephone = "0270704412", IntervenantExterieur = false, Infos = "Formateur sur les navigateurs Internet", Civilite = civilites[2] },
                new Formateur { Nom = "REIS", Prenom = "Luis", UrlPhoto = "Content/portraits/lreis.jpg", Courriel = "lreis@worldCompany.fr", Telephone = "0270704413", IntervenantExterieur = false, Infos = "Assure des formations sur les normes du marché pharmaceutique", Civilite = civilites[2] },
                new Formateur { Nom = "RUSKOV", Prenom = "Elise", UrlPhoto = "Content/portraits/eruskov.jpg", Courriel = "eruskov@worldCompany.fr", Telephone = "0683286446", IntervenantExterieur = true, Infos = "Enseigne les bases sur les architectures informatiques", Civilite = civilites[1] },
                new Formateur { Nom = "CADET", Prenom = "Nathalie", UrlPhoto = "Content/portraits/ncadet.jpg", Courriel = "ncadet@worldCompany.fr", Telephone = "0637624657", IntervenantExterieur = true, Infos = "Dispense les formations sur les usages des nouvelles molécules", Civilite = civilites[0] }
            };

            formateurs.ForEach(f => context.Formateurs.Add(f));
            context.SaveChanges();
            #endregion

            #region Commerciaux
            var commerciaux = new List<Commercial>
            {
                new Commercial { NomUtilisateur = "lseila", MotDePasse = "al153B", Nom = "SEILA", Prenom = "Louisa", Courriel = "lseila@WorldCompany.fr", Civilite = civilites[1] },
                new Commercial { NomUtilisateur = "mjoue", MotDePasse = "aloc91", Nom = "JOUE", Prenom = "Marie", Courriel = "mjoue@learningCompany.fr", Civilite = civilites[0] }
            };

            commerciaux.ForEach(com => context.Commerciaux.Add(com));
            context.SaveChanges();
            #endregion

            #region Clients
            var clients = new List<Client>
            {
                new Client { Reference = "GSB MASSON", RaisonSociale = "GSB MASSON Industries", Adresse = "10, Avenue Charles de Gaulle", CodePostal = "44000", Ville = "Nantes", Telephone = "0240334920", Courriel = "gsbinfo@masson.fr", UrlSite = "http://gsbmasson.free.fr", MotDePasse = "9084CA12", Commercial = commerciaux[1], SecteurActivite = secteursActivite[0] },
                new Client { Reference = "GSB ARIA", RaisonSociale = "GSB ARIA Industries", Adresse = "71, Route de Vannes", CodePostal = "44800", Ville = "Saint-herblain", Telephone = "0274654734", Courriel = "gsbcontact@aria.fr", UrlSite = "http://www.gsbaria.fr", MotDePasse = "386A6F48", Commercial = commerciaux[1], SecteurActivite = secteursActivite[0] },
                new Client { Reference = "GSB FDSP", RaisonSociale = "GSB FDSPROD", Adresse = "3, Allée de la Charentaise", CodePostal = "44200", Ville = "Nantes", Telephone = "0239438487", Courriel = "gsbcontact@fdsprod.com", UrlSite = "http://www.gsbfdsprod.com", MotDePasse = "523D8E41", Commercial = commerciaux[1], SecteurActivite = secteursActivite[0] },
                new Client { Reference = "GSB FINAC", RaisonSociale = "GSB Finances", Adresse = "1, Rue de la Madeleine", CodePostal = "31000", Ville = "Toulouse", Telephone = "0551839284", Courriel = "gsbcontact@gsbfinances.fr", UrlSite = "www.gsbfinances.fr", MotDePasse = "673B28CD", Commercial = commerciaux[0], SecteurActivite = secteursActivite[1] },
                new Client { Reference = "GSB MARKET", RaisonSociale = "GSB MARKETING EUROPE", Adresse = "3, allée des Allouettes", CodePostal = "31200", Ville = "Toulouse", Telephone = "0529827432", Courriel = "gsbinfo@gsbmarket.com", UrlSite = "http://www.gsbmarket.com", MotDePasse = "12CC38D0", Commercial = commerciaux[1], SecteurActivite = secteursActivite[1] },
                new Client { Reference = "GSB IDP", RaisonSociale = "GSB Industries Paris", Adresse = "176, Rue de la Liberté", CodePostal = "75000", Ville = "Paris", Telephone = "0132732949", Courriel = "gsbinfo@idp.fr", UrlSite = "www.gsbidp.fr", MotDePasse = "44ADC780", Commercial = commerciaux[1], SecteurActivite = secteursActivite[1] },
                new Client { Reference = "GSB Distri", RaisonSociale = "GSB Distribution Europe", Adresse = "65, Allée du Palais de Justice", CodePostal = "75000", Ville = "Paris", Telephone = "0129237824", Courriel = "gsbcontact@distri.com", UrlSite = "http://www.gsbdistri.com", MotDePasse = "78687ED5", Commercial = commerciaux[0], SecteurActivite = secteursActivite[1] }
            };

            clients.ForEach(cli => context.Clients.Add(cli));
            context.SaveChanges();
            #endregion

            #region Stagiaires
            var stagiaires = new List<Stagiaire>
            {
                new Stagiaire { Nom = "LEGRAND", Prenom = "David", Courriel = "david.legrand@masson.fr", Civilite = civilites[2], Client = clients[0]},
                new Stagiaire { Nom = "HAIS", Prenom = "Aurélie", Courriel = "ahais@aria.fr", Civilite = civilites[0], Client = clients[1]},
                new Stagiaire { Nom = "ELOI", Prenom = "Karl", Courriel = "karl.eloi@masson.fr", Civilite = civilites[2], Client = clients[0]},
                new Stagiaire { Nom = "DECO", Prenom = "Louise", Courriel = "louise.deco@fdsp.com", Civilite = civilites[1], Client = clients[2]},
                new Stagiaire { Nom = "FALAISE", Prenom = "Marc", Courriel = "falaise.marc@fdsp.com", Civilite = civilites[2], Client = clients[2]},
                new Stagiaire { Nom = "JOUEN", Prenom = "Baptiste", Courriel = "baptiste.jouen@fdsp.com", Civilite = civilites[2], Client = clients[2]},
                new Stagiaire { Nom = "KRON", Prenom = "Catherine", Courriel = "ckron@gsbfinances.com", Civilite = civilites[1], Client = clients[3]},
                new Stagiaire { Nom = "TREGAN", Prenom = "Aline", Courriel = "aline.tregan@gsbmarket.com", Civilite = civilites[1], Client = clients[4]},
                new Stagiaire { Nom = "PRON", Prenom = "Matthieu", Courriel = "matthieu.pron@gsbmarket.com", Civilite = civilites[2], Client = clients[4]},
                new Stagiaire { Nom = "VASSAL", Prenom = "Julien", Courriel = "vassal.julien@gsbmarket.com", Civilite = civilites[2], Client = clients[4]},
                new Stagiaire { Nom = "TERRA", Prenom = "Alice", Courriel = "alice.terra@gsbmarket.com", Civilite = civilites[0], Client = clients[4]},
                new Stagiaire { Nom = "JOURDAN", Prenom = "Catherine", Courriel = "cjourdan@wanadoo.fr", Civilite = civilites[1], Client = clients[3]},
                new Stagiaire { Nom = "TRES", Prenom = "Clémentine", Courriel = "clementine.tres@yahoo.fr", Civilite = civilites[1], Client = clients[5]},
                new Stagiaire { Nom = "RONER", Prenom = "Mathias", Courriel = "mathias.roner@laposte.net", Civilite = civilites[2], Client = clients[5]},
                new Stagiaire { Nom = "VASSORT", Prenom = "Michel", Courriel = "m.vassort@Wanadoo.fr", Civilite = civilites[2], Client = clients[6]},
                new Stagiaire { Nom = "SALDUCCI", Prenom = "Alice", Courriel = "alice.salducci@hotmail.fr", Civilite = civilites[0], Client = clients[6]}
            };

            stagiaires.ForEach(sta => context.Stagiaires.Add(sta));
            context.SaveChanges();
            #endregion

            #region Formations
            var formations = new List<Formation>
            {
                new FormationPresentielle { Reference = "B21-005", Libelle = "Découvrir les nouveautés de Microsoft Word 2010", NombreJours = 3, Prix = 850.0M, Description = "Permet d''étudier les principales fonctionnalités de Microsoft Word", Theme = themes[0], Lieu = "Avenue de la République, Salle 1 - PARIS", Formateurs = new List<Formateur>{ formateurs[5], formateurs[6] }},
                new FormationPresentielle { Reference = "B03-011", Libelle = "Excel 2010", NombreJours = 3, Prix = 800.0M, Description = "Permet de réaliser des classeurs Excel avancés avec Excel 2010", Theme = themes[0], Lieu = "Avenue de la République, Salle 2 - PARIS", Formateurs = new List<Formateur>{ formateurs[5], formateurs[6] } },
                new FormationPresentielle { Reference = "A03-012", Libelle = "Internet Explorer 10", NombreJours = 1, Prix = 600.0M, Description = "Naviguer efficacement avec Internet Explorer 10", Theme = themes[1], Lieu = "Avenue de la République, Salle 3 - PARIS", Formateurs = new List<Formateur>{ formateurs[5], formateurs[6], formateurs[11] } },
                new FormationPresentielle { Reference = "A03-013", Libelle = "Mozilla Firefox", NombreJours = 1, Prix = 600.0M, Description = "Naviguer efficacement avec Mozilla Firefox", Theme = themes[2], Lieu = "Avenue de la République, Salle 4 - PARIS", Formateurs = new List<Formateur>{ formateurs[5], formateurs[6], formateurs[11] } },
                new FormationPresentielle { Reference = "T06-034", Libelle = "Ordinateurs portables", NombreJours = 2, Prix = 1100.0M, Description = "La prise en main des ordinateurs portables IBM sous Windows 7", Theme = themes[3], Lieu = "Avenue de la République, Salle 5 - PARIS", Formateurs = new List<Formateur>{ formateurs[5], formateurs[6], formateurs[10], formateurs[13] } },
                new FormationPresentielle { Reference = "T01-010", Libelle = "Initiation à Excel", NombreJours = 2, Prix = 350.0M, Description = "Apprendre les bases des formules des classeurs sous Exel", Theme = themes[0], Lieu = "Avenue de la République, Salle 2 - PARIS", Formateurs = new List<Formateur>{ formateurs[5], formateurs[6] } },
                new FormationPresentielle { Reference = "T23-011", Libelle = "Le médecin généraliste", NombreJours = 2, Prix = 2300.0M, Description = "Psychologie du médecin généraliste en milieu urbain", Theme = themes[8], Lieu = "Avenue de la République, Salle 3 - PARIS", Formateurs = new List<Formateur>{ formateurs[8] } },
                new FormationPresentielle { Reference = "T23-012", Libelle = "Le médecin généraliste", NombreJours = 2, Prix = 2300.0M, Description = "Psychologie du médecin généraliste en milieu rural", Theme = themes[8], Lieu = "Avenue de la République, Salle 1 - PARIS", Formateurs = new List<Formateur>{ formateurs[8] } },
                new FormationPresentielle { Reference = "D12-090", Libelle = "Le dédecin spécialiste", NombreJours = 2, Prix = 2300.0M, Description = "Psychologie du médecin spécialiste en milieu libéral", Theme = themes[8], Lieu = "Avenue de la République, Salle 4 - PARIS", Formateurs = new List<Formateur>{ formateurs[8] } },
                new FormationPresentielle { Reference = "D12-091", Libelle = "Le dédecin spécialiste", NombreJours = 2, Prix = 2300.0M, Description = "Psychologie du médecin spécialiste hospitalier", Theme = themes[8], Lieu = "Avenue de la République, Salle 5 - PARIS", Formateurs = new List<Formateur>{ formateurs[8] } },
                new FormationElearning { Reference = "T02-055", Libelle = "Les statines", NombreJours = 2, Prix = 1000.0M, Description = "Les statines de nouvelles générations pour le traitement du cholestérol", Theme = themes[7], Url = "http://www.learningcompany.fr/1.htm", Formateurs = new List<Formateur>{ formateurs[1], formateurs[2], formateurs[14] } },
                new FormationElearning { Reference = "T04-025", Libelle = "Les antibiotiques", NombreJours = 3, Prix = 1400.0M, Description = "Les antibiotiques de la catégorie Macrolid", Theme = themes[7], Url = "http://www.learningcompany.fr/2.htm", Formateurs = new List<Formateur>{ formateurs[1], formateurs[2], formateurs[14] } },
                new FormationElearning { Reference = "T02-059", Libelle = "Réglementation nationale", NombreJours = 2, Prix = 899.0M, Description = "Les nouveaux réglements Agence Nationale de Sécurité du Médicament (ANSM)", Theme = themes[8], Url = "http://www.learningcompany.fr/3.htm", Formateurs = new List<Formateur>{ formateurs[9], formateurs[12] } },
                new FormationElearning { Reference = "T02-162", Libelle = "Documentation commerciale", NombreJours = 4, Prix = 500.0M, Description = "Les documents de communication destinés aux médecins", Theme = themes[8], Url = "http://www.learningcompany.fr/4.htm", Formateurs = new List<Formateur>{ formateurs[1], formateurs[7] } },
                new FormationElearning { Reference = "T02-163", Libelle = "Visite médicale", NombreJours = 4, Prix = 2000.0M, Description = "Les étapes des entretiens du délégué médical avec le médecin", Theme = themes[8], Url = "http://www.learningcompany.fr/5.htm", Formateurs = new List<Formateur>{ formateurs[8], formateurs[7] } },
                new FormationElearning { Reference = "T05-985", Libelle = "Tranfert de données", NombreJours = 1, Prix = 500.0M, Description = "La transmission VPN des dossiers du délégué médical", Theme = themes[4], Url = "http://www.learningcompany.fr/6.htm", Formateurs = new List<Formateur>{ formateurs[5], formateurs[6] } },
                new FormationElearning { Reference = "T02-162", Libelle = "Les effets secondaires", NombreJours = 2, Prix = 900.0M, Description = "Prévention des effets secondaires du paracétamol", Theme = themes[5], Url = "http://www.learningcompany.fr/7.htm", Formateurs = new List<Formateur>{ formateurs[3], formateurs[2] } },
                new FormationElearning { Reference = "T15-039", Libelle = "Interactions médicamenteuses", NombreJours = 1, Prix = 500.0M, Description = "Introduction aux interactions médicamenteuses", Theme = themes[6], Url = "http://www.learningcompany.fr/8.htm", Formateurs = new List<Formateur>{ formateurs[0], formateurs[1], formateurs[3], formateurs[2] } },
                new FormationElearning { Reference = "T15-040", Libelle = "Interactions médicamenteuses", NombreJours = 1, Prix = 500.0M, Description = "Interactions médicamenteuses chez les personnes agées", Theme = themes[6], Url = "http://www.learningcompany.fr/9.htm", Formateurs = new List<Formateur>{ formateurs[0], formateurs[1], formateurs[3], formateurs[2] } },
            };

            formations.ForEach(f => context.Formations.Add(f));
            context.SaveChanges();
            #endregion

            #region Sessions
            var sessions = new List<SessionFormation>
            {
                new SessionFormation { Formation = formations[0], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 14), DateFin = new DateTime(2009, 09, 16), Intervenant = false, Formateur = formateurs[5], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[0], stagiaires[1], stagiaires[3] } },
                new SessionFormation { Formation = formations[0], SessionFormationID = 2, DateDebut = new DateTime(2009, 09, 28), DateFin = new DateTime(2009, 09, 30), Intervenant = true, Formateur = formateurs[10], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[14], stagiaires[8] } },
                new SessionFormation { Formation = formations[1], SessionFormationID = 1, DateDebut = new DateTime(2009, 10, 05), DateFin = new DateTime(2009, 10, 09), Intervenant = true, Formateur = formateurs[6], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[9] } },
                new SessionFormation { Formation = formations[2], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 07), DateFin = new DateTime(2009, 09, 11), Intervenant = false, Formateur = formateurs[1], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[15], stagiaires[10] } },
                new SessionFormation { Formation = formations[2], SessionFormationID = 2, DateDebut = new DateTime(2009, 09, 14), DateFin = new DateTime(2009, 09, 18), Intervenant = false, Formateur = formateurs[12], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[8], stagiaires[11], stagiaires[3] } },
                new SessionFormation { Formation = formations[4], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 21), DateFin = new DateTime(2009, 09, 23), Intervenant = true, Formateur = formateurs[7], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[6] } },
                new SessionFormation { Formation = formations[6], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 24), DateFin = new DateTime(2009, 09, 25), Intervenant = true, Formateur = formateurs[8], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[13] } },
                new SessionFormation { Formation = formations[7], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 21), DateFin = new DateTime(2009, 09, 25), Intervenant = false, Formateur = formateurs[2], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[4], stagiaires[3] } },
                new SessionFormation { Formation = formations[8], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 21), DateFin = new DateTime(2009, 09, 22), Intervenant = true, Formateur = formateurs[1], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[7], stagiaires[1] } },
                new SessionFormation { Formation = formations[15], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 23), DateFin = new DateTime(2009, 09, 25), Intervenant = true, Formateur = formateurs[2], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[0], stagiaires[6] } },
                new SessionFormation { Formation = formations[16], SessionFormationID = 1, DateDebut = new DateTime(2009, 11, 23), DateFin = new DateTime(2009, 11, 26), Intervenant = true, Formateur = formateurs[8], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[10], stagiaires[11], stagiaires[12] } },
                new SessionFormation { Formation = formations[10], SessionFormationID = 1, DateDebut = new DateTime(2009, 11, 09), DateFin = new DateTime(2009, 11, 10), Intervenant = true, Formateur = formateurs[8], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[9], stagiaires[3], stagiaires[7] } },
                new SessionFormation { Formation = formations[12], SessionFormationID = 1, DateDebut = new DateTime(2009, 12, 07), DateFin = new DateTime(2009, 12, 11), Intervenant = true, Formateur = formateurs[8], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[0] } },
                new SessionFormation { Formation = formations[13], SessionFormationID = 1, DateDebut = new DateTime(2009, 11, 23), DateFin = new DateTime(2009, 11, 27), Intervenant = true, Formateur = formateurs[8], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[11], stagiaires[3] } },
                new SessionFormation { Formation = formations[17], SessionFormationID = 1, DateDebut = new DateTime(2009, 09, 21), DateFin = new DateTime(2009, 09, 23), Intervenant = true, Formateur = formateurs[10], Commercial = commerciaux[0], Stagiaires = new Stagiaire[] { stagiaires[13] } },
                new SessionFormation { Formation = formations[18], SessionFormationID = 1, DateDebut = new DateTime(2009, 10, 12), DateFin = new DateTime(2009, 10, 16), Intervenant = true, Formateur = formateurs[10], Commercial = commerciaux[1], Stagiaires = new Stagiaire[] { stagiaires[12] } }
            };

            sessions.ForEach(s => context.SessionsFormations.Add(s));
            context.SaveChanges();
            #endregion

            #region Demandes Clients
            var demandes = new List<DemandeClient> 
            {
                new DemandeClient { Client = clients[0], Formation = formations[0], DateDemande = new DateTime(2010, 06, 20), DateTraitement = null },
                new DemandeClient { Client = clients[6], Formation = formations[0], DateDemande = new DateTime(2010, 07, 24), DateTraitement = null },
                new DemandeClient { Client = clients[0], Formation = formations[1], DateDemande = new DateTime(2010, 07, 25), DateTraitement = new DateTime?(new DateTime(2010, 07, 27, 20, 51, 28)) },
                new DemandeClient { Client = clients[6], Formation = formations[1], DateDemande = new DateTime(2010, 06, 20), DateTraitement = null },
                new DemandeClient { Client = clients[0], Formation = formations[2], DateDemande = new DateTime(2010, 07, 24), DateTraitement = null },
                new DemandeClient { Client = clients[1], Formation = formations[6], DateDemande = new DateTime(2010, 06, 20), DateTraitement = new DateTime?(new DateTime(2010, 07, 23, 20, 51, 28)) },
                new DemandeClient { Client = clients[5], Formation = formations[7], DateDemande = new DateTime(2010, 06, 20), DateTraitement = null },
                new DemandeClient { Client = clients[2], Formation = formations[7], DateDemande = new DateTime(2010, 06, 20), DateTraitement = null },
                new DemandeClient { Client = clients[3], Formation = formations[8], DateDemande = new DateTime(2010, 07, 24), DateTraitement = null },
                new DemandeClient { Client = clients[5], Formation = formations[8], DateDemande = new DateTime(2010, 08, 01), DateTraitement = new DateTime?(new DateTime(2010, 08, 06, 20, 51, 28)) },
                new DemandeClient { Client = clients[4], Formation = formations[9], DateDemande = new DateTime(2010, 07, 25), DateTraitement = new DateTime?(new DateTime(2010, 07, 27, 20, 51, 28)) },
                new DemandeClient { Client = clients[1], Formation = formations[11], DateDemande = new DateTime(2010, 08, 01), DateTraitement = new DateTime?(new DateTime(2010, 08, 06, 20, 51, 28)) },
                new DemandeClient { Client = clients[4], Formation = formations[13], DateDemande = new DateTime(2010, 07, 24), DateTraitement = null },
                new DemandeClient { Client = clients[2], Formation = formations[15], DateDemande = new DateTime(2010, 07, 25), DateTraitement = null },
                new DemandeClient { Client = clients[3], Formation = formations[17], DateDemande = new DateTime(2010, 07, 25), DateTraitement = new DateTime?(new DateTime(2010, 07, 06, 20, 51, 28)) },
            };

            demandes.ForEach(d => context.DemandesClients.Add(d));
            context.SaveChanges();
            #endregion

        }
    }
}
