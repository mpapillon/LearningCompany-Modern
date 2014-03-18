using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LearningCompany.Entities
{
    public class LearningCompanyContext : DbContext
    {
        public LearningCompanyContext()
            : base("LearningCompanyContext")
        {
        }

        public DbSet<Commercial> Commerciaux { get; set; }
        public DbSet<Formateur> Formateurs { get; set; }
        public DbSet<Stagiaire> Stagiaires { get; set; }

        public DbSet<Formation> Formations { get; set; }
        public DbSet<FormationElearning> FormationsElearning { get; set; }
        public DbSet<FormationPresentielle> FormationsPresentielles { get; set; }
        public DbSet<SessionFormation> SessionsFormations { get; set; }

        public DbSet<Civilite> Civilites { get; set; }
        public DbSet<SecteurActivite> SecteursActivites { get; set; }
        public DbSet<Theme> Themes { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<DemandeClient> DemandesClients { get; set; }
    }
}
