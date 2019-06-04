namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineAccount : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            var order = 1;

            new DefaultTableAndSchemaNamingConvention().Define<TenancySecurityProfile>(modelBuilder);

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenancySecurityProfile>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            //modelBuilder.DefineTitleAndDescription<Account>(ref order, true, false);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
            modelBuilder.Entity<TenancySecurityProfile>()
                .HasMany(s => s.AccountGroups)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable(typeof(TenancySecurityProfile).Name + "__" + typeof(TenancySecurityProfileRoleGroup).Name);
                    x.MapLeftKey("AccountFK");
                    x.MapRightKey("AccountGroupFK");
                });
            modelBuilder.Entity<TenancySecurityProfile>()
                .HasMany(s => s.Roles)
                .WithMany()
                .Map(x =>
                {
                    x.ToTable(typeof(TenancySecurityProfile).Name + "__" + typeof(TenancySecurityProfileAccountRole).Name);
                    x.MapLeftKey("AccountFK");
                    x.MapRightKey("RoleFK");
                });
            // --------------------------------------------------

        }
    }
}

