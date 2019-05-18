namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.Configuration;
    using App.Modules.Core.Shared.Models.Configuration.AppHost;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // Seeder invoked by reflection (see: DbContextSeedingOrchestrator)
    public class CoreModuleDbContextSeederPrincipalCategory : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederPrincipalCategory(IHostSettingsService hostSettingsService)
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
            var records = new[]
            {
                //People:
                GetDefaultPrincipalCategory(),
                GetSystemPrincipalCategory(),
            };
            context.Set<PrincipalCategory>().AddOrUpdateBasedOnId( records);
            context.SaveChanges();
        }

        public static PrincipalCategory GetDefaultPrincipalCategory()
        {
            return new PrincipalCategory() {Id = 1.ToGuid(), Enabled = true, Title = "Default"};
        }

        public static PrincipalCategory GetSystemPrincipalCategory()
        {
            return new PrincipalCategory() { Id = 2.ToGuid(), Enabled = true, Title = "System" };
        }

        protected void SeedDevOnlyEntries(CoreModuleDbContext context)
        {
        }


    }
}