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
    public class CoreModuleDbContextSeederTenantClaim : IHasAppModuleDbContextSeedInitializer
    {



        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederTenantClaim(IHostSettingsService hostSettingsService)
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
            context.Set<TenantClaim>().AddOrUpdateBasedOnId( records);
        }
    }
}