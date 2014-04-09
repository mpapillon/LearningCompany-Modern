using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearningCompany.Entities;

namespace LearningCompany_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Commercial unCommercial = new Commercial()
            {
                Nom = "Jean",
                Prenom = "Aimarre",
                NomUtilisateur = "jaimarre",
                MotDePasse = "azerty",
                Courriel = "jaimarre@mail.com",
                Civilite = new Civilite() { LibelleCourt = "M", LibelleLong = "Monsieur" },
            };
        }
    }
}
