using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantMemberSecurityProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantMemberSecurityProfile : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Shared.Models.Entities.TenantMemberSecurityProfile>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Shared.Models.Entities.TenantMemberSecurityProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<Shared.Models.Entities.TenantMemberSecurityProfile>()
                .HasOne(x => x.SecurityProfile)
                .WithMany()
                .HasForeignKey(x => x.SecurityProfileFK);
            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.

            modelBuilder.Entity<Shared.Models.Entities.TenantMemberSecurityProfile>()
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

