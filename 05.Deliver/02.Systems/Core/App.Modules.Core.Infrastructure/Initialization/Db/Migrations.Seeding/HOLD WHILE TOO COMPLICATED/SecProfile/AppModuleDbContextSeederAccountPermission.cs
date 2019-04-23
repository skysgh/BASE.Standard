namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Contracts;

    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    [OrderBy(After = "Group,Role")]
    public class CoreModuleDbContextSeederAccountPermission : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederAccountPermission(IHostSettingsService hostSettingsService)
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
            var records = new TenancySecurityProfilePermission[]
            {
// for Role 1:
                new TenancySecurityProfilePermission
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 1.ToGuid(),
                    Title = "Permission 1"
                },
                new TenancySecurityProfilePermission
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 2.ToGuid(),
                    Title = "Permission 2"
                },
// for Role 2:
                new TenancySecurityProfilePermission
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 3.ToGuid(),
                    Title = "Permission 3"
                },
                new TenancySecurityProfilePermission
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 4.ToGuid(),
                    Title = "Permission 4"
                },
// for Role 3:
                new TenancySecurityProfilePermission
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 5.ToGuid(),
                    Title = "Permission 5"
                },
                new TenancySecurityProfilePermission
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 6.ToGuid(),
                    Title = "Permission 6"
                },
                new TenancySecurityProfilePermission
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 7.ToGuid(),
                    Title = "Permission 7"
                }
            };

            var dbSet = context.Set<TenancySecurityProfilePermission>();

            dbSet.AddOrUpdateBasedOnId(records);

            context.SaveChanges();
        }
    }
}

