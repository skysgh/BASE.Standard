using App.Modules.Core.Infrastructure.Constants.Db;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities.TenantMember.Profile;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantMemberProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantMemberProfileTag : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfileTag>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;


            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberProfileTag>(modelBuilder, ref order);

            // --------------------------------------------------
            // Indexes:
            modelBuilder.AssignIndex<TenantMemberProfileTag>(x => x.Title,false);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantMemberProfileTag>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<TenantMemberProfileTag>()
                .Property(x => x.Title)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<TenantMemberProfileTag>()
                .Property(x => x.DisplayOrderHint)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<TenantMemberProfileTag>()
                .Property(x => x.DisplayStyleHint)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(false);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}