namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Contracts;

    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    [OrderBy(After = "Group,Role,Permission")]
    public class CoreModuleDbContextSeederAccount : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederAccount(IHostSettingsService hostSettingsService)
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

        protected void SeedImmutableEntries(CoreModuleDbContext context)
        {
        }

        protected void SeedDevOnlyEntries(CoreModuleDbContext context)
        {
            var g = context.Set<TenancySecurityProfileRoleGroup>().Where(x => x.TenantFK == App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();
            var r = context.Set<TenancySecurityProfileAccountRole>().Where(x => x.TenantFK == App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();

            var records = new TenancySecurityProfile[]
            {
                new TenancySecurityProfile
                {
                    Id = 1.ToGuid(),
                    Key = "jsmith@whatever.com",
                },
                new TenancySecurityProfile
                {
                    Id = 2.ToGuid(),
                    Key = "bboop@okifnotsameastenancy.com",
                    Roles = new Collection<TenancySecurityProfileAccountRole>(){ r.Where(x => x.Id == 3.ToGuid()).SingleOrDefault() }
                }
            };

            var dbSet = context.Set<TenancySecurityProfile>();

            dbSet.AddOrUpdateBasedOnId(records);

            context.SaveChanges();
        }
    }
}

