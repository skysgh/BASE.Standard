namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederTenantProperty : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederTenantProperty(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            var records = new[]
            {
                new TenantProperty {Id = 1.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropA", Value = "SomeValueA1"},
                new TenantProperty {Id = 2.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropB", Value = "SomeValueB1"},
                new TenantProperty {Id = 3.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropC", Value = "SomeValueC1"},
                new TenantProperty {Id = 4.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropD", Value = "SomeValueD1"}
            };
            moduleDbContext.Set<TenantProperty>().AddOrUpdateBasedOnId( records);
            moduleDbContext.SaveChanges();
        }
    }
}