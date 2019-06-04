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
    [OrderBy(After = "Group,Role")]
    public class AppModuleDbContextSeederAccountRole : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccountRole(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {

            var p = context.Set<TenancySecurityProfilePermission>().Where(x => x.TenantFK == App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();

            var records = new TenancySecurityProfileAccountRole[]
            {
                new TenancySecurityProfileAccountRole
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 1.ToGuid(),
                    Title="Role 1",
                    Permissions = new Collection<TenancySecurityProfilePermission>() {
                        p.Single(x=>x.Id == 1.ToGuid()),
                        p.Single(x=>x.Id == 2.ToGuid())
                    }
                },
                new TenancySecurityProfileAccountRole
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 2.ToGuid(),
                    Title="Role 2",
                    Permissions = new Collection<TenancySecurityProfilePermission>() {
                        p.Single(x=>x.Id == 3.ToGuid()),
                        p.Single(x=>x.Id == 4.ToGuid())
                    }
                },
                new TenancySecurityProfileAccountRole
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 3.ToGuid(),
                    Title="Role 3",
                    Permissions = new Collection<TenancySecurityProfilePermission>() {
                        p.Single(x=>x.Id == 5.ToGuid()),
                        p.Single(x=>x.Id == 6.ToGuid()),
                        p.Single(x=>x.Id == 7.ToGuid())
                    }
                }
            };

            var dbSet = context.Set<TenancySecurityProfileAccountRole>();

            dbSet.AddOrUpdateBasedOnId(records);

            moduleDbContext.SaveChanges();
        }
    }
}

