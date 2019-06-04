using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantMemberSecurityProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantMemberSecurityProfile : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Models.Entities.TenantMemberSecurityProfile>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Models.Entities.TenantMemberSecurityProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<Models.Entities.TenantMemberSecurityProfile>()
                .HasOne(x => x.SecurityProfile)
                .WithMany()
                .HasForeignKey(x => x.SecurityProfileFK);
            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.

            modelBuilder.Entity<Models.Entities.TenantMemberSecurityProfile>()
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

