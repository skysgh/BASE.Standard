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
    public class CoreModuleDbContextSeederAccountRoleAccountPermissionAssignment : IHasAppModuleDbContextSeedInitializer, IHasIgnoreThis
    {
        private readonly IHostSettingsService _hostSettingsService;

        public CoreModuleDbContextSeederAccountRoleAccountPermissionAssignment(IHostSettingsService hostSettingsService)
        {
            this._hostSettingsService = hostSettingsService;
        }

        public void Seed(ModuleDbContextBase moduleDbContext)
        {
            var records = new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment[]
            {
// for Role 1:
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 1.ToGuid(),
                    PermissionFK = 1.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 1.ToGuid(),
                    PermissionFK = 2.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
// for Role 2:
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 2.ToGuid(),
                    PermissionFK = 3.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 2.ToGuid(),
                    PermissionFK = 4.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
// for Role 3:
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 3.ToGuid(),
                    PermissionFK = 5.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 3.ToGuid(),
                    PermissionFK = 6.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
                new TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment
                {
                    TenantFK = App.Modules.Core.Infrastructure.Constants.Demo.Tenancies.A.Id,
                    RoleFK = 3.ToGuid(),
                    PermissionFK = 7.ToGuid(),
                    AssignmentType = AssignmentType.Add
                },
            };

            var dbSet = moduleDbContext.Set<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>();

            dbSet.AddOrUpdateBasedOnIds(x => new { x.RoleFK,x.PermissionFK}, records);

            moduleDbContext.SaveChanges();
        }
    }
}

