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
    public class CoreModuleDbContextSeederSessionOperation : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {


        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederSessionOperation(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            //            var records = new[]
            //        {
            //            //People:
            //            new SessionOperation
            //            {
            //                Id = 1.ToGuid(),
            //                SessionFK = 1.ToGuid(),
            //                ClientIp = "12.34.56.78",
            //                Url = "https://localhost:123/TenantA/Foo/Bar/12",
            //                ResourceTenantKey="TenantA",
            //                ControllerName = "FooController",
            //                ActionName = "BarAction",
            //                ActionArguments = "12",
            //                Duration = TimeSpan.FromMilliseconds(112),
            //                ResponseCode = "200"
            //},
            //        };
            //        moduleDbContext.Set<SessionOperation>().AddOrUpdateBasedOnId( records);
            //        moduleDbContext.SaveChanges();
        }


    }
}