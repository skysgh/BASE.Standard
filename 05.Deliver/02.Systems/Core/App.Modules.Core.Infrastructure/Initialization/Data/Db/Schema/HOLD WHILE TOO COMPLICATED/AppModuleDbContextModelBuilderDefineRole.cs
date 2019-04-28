namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineRole : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<TenancySecurityProfileAccountRole>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenancySecurityProfileAccountRole>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.
            modelBuilder.DefineTitleAndDescription<TenancySecurityProfileAccountRole>(ref order);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
            modelBuilder.Entity<TenancySecurityProfileAccountRole>()
                .HasMany(s => s.Permissions)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable(typeof(TenancySecurityProfileAccountRole).Name + "__" + typeof(TenancySecurityProfilePermission).Name);
                    x.MapLeftKey("RoleFK");
                    x.MapRightKey("PermissionFK");
                });
        }

    }
}

