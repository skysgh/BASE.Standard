namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederTenantProperty : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederTenantProperty(IHostSettingsService hostSettingsService)
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
                new TenantProperty {Id = 1.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropA", Value = "SomeValueA1"},
                new TenantProperty {Id = 2.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropB", Value = "SomeValueB1"},
                new TenantProperty {Id = 3.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropC", Value = "SomeValueC1"},
                new TenantProperty {Id = 4.ToGuid(), TenantFK = Constants.Demo.Tenancies.B.Id, Key = "SomePropD", Value = "SomeValueD1"}
            };
            context.Set<TenantProperty>().AddOrUpdateBasedOnId( records);
            context.SaveChanges();
        }
    }
}