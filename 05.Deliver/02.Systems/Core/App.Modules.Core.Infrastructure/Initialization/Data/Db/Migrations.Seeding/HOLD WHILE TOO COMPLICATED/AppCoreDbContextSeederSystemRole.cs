namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using App.Modules.Core.Infrastructure.Constants.Roles;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederSystemRole : IHasAppModuleDbContextSeedInitializer
    {


        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederSystemRole(IHostSettingsService hostSettingsService)
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
        }

        protected void SeedDevOnlyEntries(CoreModuleDbContext context)
        {
                var records = new[]
            {
                //People:
                new SystemRole
                {
                    Id = 1.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.SystemUser,
                    DataClassificationFK = NZDataClassification.InConfidence,
                },
                new SystemRole
                {
                    Id = 2.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.SystemAdmin,
                    DataClassificationFK = NZDataClassification.InConfidence,
                },
                //People:
                new SystemRole
                {
                    Id = 3.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.TenantMember,
                    DataClassificationFK = NZDataClassification.InConfidence
                },
                new SystemRole
                {
                    Id = 4.ToGuid(),
                    Enabled = false,
                    ModuleKey=Constants.Module.Names.ModuleKey,
                    Key =  Constants.Roles.RoleKeys.TenantAdmin,
                    DataClassificationFK = NZDataClassification.InConfidence,
                }
            };
            context.Set<SystemRole>().AddOrUpdateBasedOnId( records);
            context.SaveChanges();
        }


    }
}