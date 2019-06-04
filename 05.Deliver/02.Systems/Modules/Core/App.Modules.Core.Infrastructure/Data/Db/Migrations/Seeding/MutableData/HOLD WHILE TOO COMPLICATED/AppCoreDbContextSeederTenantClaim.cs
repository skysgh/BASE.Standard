namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederTenantClaim : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {



        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederTenantClaim(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            var records = new[]
            {
                new TenantClaim
                {
                    Id = 1.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.A.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropA",
                    Value = "SomeValueA1"
                },
                new TenantClaim
                {
                    Id = 2.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.A.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropB",
                    Value = "SomeValueB1"
                },

                new TenantClaim
                {
                    Id = 3.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.B.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropA",
                    Value = "SomeValueA1"
                },
                new TenantClaim
                {
                    Id = 4.ToGuid(),
                    TenantFK = Constants.Demo.Tenancies.B.Id,
                    Authority = "N/A",
                    AuthoritySignature = "A",
                    Key = "SomePropB",
                    Value = "SomeValueB1"
                }
            };
            moduleDbContext.Set<TenantClaim>().AddOrUpdateBasedOnId( records);
        }
    }
}