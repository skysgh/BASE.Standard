using App.Modules.Core.Shared.Models.Entities.TenancySpecific;

namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineTenantMemberSecurityProfile : IHasModuleSpecificDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<TenantMemberSecurityProfile>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberSecurityProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantMemberSecurityProfile>()
                .HasOne(x => x.SecurityProfile)
                .WithMany()
                .HasForeignKey(x => x.SecurityProfileFK);
            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.

            modelBuilder.Entity<TenantMemberSecurityProfile>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigation Properties:


            // --------------------------------------------------
            // Collection Navigation Properties:

        }

    }
}

