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
        public class CoreModuleDbContextSeederPrincipal : IHasAppModuleDbContextSeedInitializer
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederPrincipal(IHostSettingsService hostSettingsService)
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
                new Principal {Id = Constants.Users.Anon.Id, Enabled = true, CategoryFK = 1.ToGuid(), DisplayName = Constants.Users.Anon.Name},
                //new Principal {Id = Constants.Users.SysDaemon.Id, Enabled = true, CategoryFK = 2.ToGuid(), DisplayName = Constants.Users.SysDaemon.Name},
            };

            context.Set<Principal>().AddOrUpdateBasedOnId( records);
            context.SaveChanges();
        }

        protected void SeedDevOnlyEntries(CoreModuleDbContext context)
        {
            //    var records = new[]
            //{
            //    //People:
            //    new Principal {Id = Constants.Demo.Users.U1.Id, Enabled = true, CategoryFK = 1.ToGuid(), DisplayName = Constants.Demo.Users.U1.Name},
            //    new Principal {Id = Constants.Demo.Users.U2.Id, Enabled = true, CategoryFK = 1.ToGuid(), DisplayName = Constants.Demo.Users.U2.Name}
            //};
            //context.Set<Principal>().AddOrUpdateBasedOnId( records);
            //context.SaveChanges();
        }


    }
}