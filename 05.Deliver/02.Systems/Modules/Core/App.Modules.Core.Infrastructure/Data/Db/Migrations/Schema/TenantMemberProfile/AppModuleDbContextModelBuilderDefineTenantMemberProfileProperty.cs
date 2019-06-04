using App.Modules.Core.Infrastructure.Constants.Db;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities.TenantMember.Profile;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantMemberProfile
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineTenantMemberProfileProperty : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    { 
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfileProperty>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;


            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberProfileProperty>(modelBuilder, ref order);


            // --------------------------------------------------
            // Indexes:
            modelBuilder.AssignIndex<TenantMemberProfileProperty>(x => new { x.PrincipalProfileFK, x.Key }, true);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantMemberProfileProperty>()
                .Property(x => x.PrincipalProfileFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantMemberProfileProperty>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<TenantMemberProfileProperty>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------

        }
    }
}