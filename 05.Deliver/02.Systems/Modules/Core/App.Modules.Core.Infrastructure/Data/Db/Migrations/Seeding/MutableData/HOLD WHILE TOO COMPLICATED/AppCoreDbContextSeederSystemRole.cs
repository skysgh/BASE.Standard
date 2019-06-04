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
    public class CoreModuleDbContextSeederSystemRole : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {


        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederSystemRole(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

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
            moduleDbContext.Set<SystemRole>().AddOrUpdateBasedOnId( records);
            moduleDbContext.SaveChanges();
        }


    }
}