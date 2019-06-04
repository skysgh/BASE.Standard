namespace App.Modules.Core.Infrastructure.Db.Migrations.Seeding
{
    using System.Linq;
    using App.Modules.Core.Infrastructure.Data;
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services;
    using App.Modules.Core.Shared.Models.ConfigurationSettings;
    using App.Modules.Core.Shared.Models.Entities;

    // A single DbContext Entity model seeder, 
    // invoked via AppModuleModelBuilderOrchestrator
    public class AppModuleDbContextSeederAccountRoleGroup : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public AppModuleDbContextSeederAccountRoleGroup(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            var r = context.Set<TenancySecurityProfileAccountRole>().Where(x => x.TenantFK == App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id).ToArray();


            var records = new TenancySecurityProfileRoleGroup[]
            {
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 1.ToGuid(),
                    Title = "GroupA",
                    Description = "...."
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 2.ToGuid(),
                    Title = "GroupB"
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 3.ToGuid(),
                    ParentFK = 2.ToGuid(),
                    Title = "GroupB.1",
                    Description = "A Group nested under GroupB"
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 4.ToGuid(),
                    ParentFK = 2.ToGuid(),
                    Title = "GroupB.2",
                    Description = "A Group nested under GroupB"
                },
                new TenancySecurityProfileRoleGroup
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    Id = 5.ToGuid(),
                    ParentFK = 4.ToGuid(),
                    Title = "GroupB.2.1",
                    Description = "A Group nested under GroupB.2",
                }
            };


            var dbSet = context.Set<TenancySecurityProfileRoleGroup>();
            dbSet.AddOrUpdateBasedOnId(records);



            context.SaveChanges();
        }
    }
}

