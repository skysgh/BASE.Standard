namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederDataClassification : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederDataClassification(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(CoreModuleDbContext context)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            SeedImmutableEntries(context);

            if (debuggerConfiguration.CodeFirstSeedDemoStuff)
            {
                SeedDevOnlyEntries(context);
            }
        }
        /// <summary>
        /// Seed records that are part of this Module, no matter what (Immutable).
        /// <para>
        /// NOT the right place for demo entries, or data that will be updated
        /// by end users.
        /// </para>
        /// </summary>
        /// <param name="context"></param>
        protected void SeedImmutableEntries(CoreModuleDbContext context)
        {
            {
                var records = new[]{             
                    //Policy and Privacy:
                    new DataClassification
                    {
                        Id = NZDataClassification.Unspecified,
                        Title = "Unspecified",
                        DisplayOrderHint = 1
                    },
                    new DataClassification
                    {
                        Id = NZDataClassification.Unclassified,
                        Title = "Unclassified",
                        DisplayOrderHint = 2
                    },
                    new DataClassification
                    {
                        Id = NZDataClassification.InConfidence,
                        Title = "In Confidence",
                        DisplayOrderHint = 3
                    },
                    new DataClassification
                    {
                        Id = NZDataClassification.Sensitive,
                        Title = "Sensitive",
                        DisplayOrderHint = 4
                    },
                    //National Security:
                    new DataClassification
                    {
                        Id = NZDataClassification.Restricted,
                        Title = "Restricted",
                        DisplayOrderHint = 5
                    },
                    new DataClassification
                    {
                        Id = NZDataClassification.Confidential,
                        Title = "Confidential",
                        DisplayOrderHint = 6
                    },
                    new DataClassification
                    {
                        Id = NZDataClassification.Secret,
                        Title = "Secret",
                        DisplayOrderHint = 7
                    },
                    new DataClassification
                    {
                        Id = NZDataClassification.TopSecret,
                        Title = "TopSecret",
                        DisplayOrderHint = 8
                    }
                };

                context.Set<DataClassification>().AddOrUpdateBasedOnId(records);
                context.SaveChanges();
            }
        }

        private static void SeedDevOnlyEntries(CoreModuleDbContext context)
        {
        }

    }
}
