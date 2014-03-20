//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using LearningCompany.Entities;
using System.Data.Services.Providers;

namespace LearningCompany.Services
{
    public class AccesCommerciaux : EntityFrameworkDataService<LearningCompanyContext>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            // config.SetEntitySetAccessRule("MyEntityset", EntitySetRights.AllRead);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);

            config.SetEntitySetAccessRule("Civilites", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Formateurs", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Clients", EntitySetRights.AllRead);
            config.SetEntitySetAccessRule("Stagiaires", EntitySetRights.AllRead);

            config.SetServiceOperationAccessRule("GetFormateurByName", ServiceOperationRights.AllRead);

            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        [WebGet]
        public Formateur GetFormateurByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("city",
                    "You must provide a value for the parameter'city'.");
            }

            var db = new LearningCompanyContext();

            var formateur = db.Formateurs.FirstOrDefault(f => f.Nom == name);
            return formateur;
        }
    }
}
