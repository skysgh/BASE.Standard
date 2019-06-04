namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using System;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederSession : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {


        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederSession(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            CodeFirstMigrationConfigurationSettings debuggerConfiguration =
                this._hostSettingsService.GetObject<CodeFirstMigrationConfigurationSettings>();

            //    var records = new[]
            //{
            //    new Session
            //    {
            //        Id = 0.ToGuid(),
            //        Enabled = false,
            //        CreatedOnUtc = DateTime.UtcNow,
            //        PrincipalFK = 0.ToGuid()
            //    },

            //        new Session
            //    {
            //        Id = 1.ToGuid(),
            //        Enabled = false,
            //        CreatedOnUtc = DateTime.UtcNow.AddDays(-3),
            //        PrincipalFK = 1.ToGuid()
            //    },
            //    new Session
            //    {
            //        Id = 2.ToGuid(),
            //        Enabled = false,
            //        CreatedOnUtc = DateTime.UtcNow.AddDays(-6),
            //        PrincipalFK = 1.ToGuid()
            //    }
            //};
            //moduleDbContext.Set<Session>().AddOrUpdateBasedOnId( records);
            //moduleDbContext.SaveChanges();
        }


    }
}