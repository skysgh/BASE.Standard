using App.Modules.Core.Infrastructure.Constants.Db;
using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities.TenantMember.Profile;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantMemberProfile
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineTenantMemberProfileClaim : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    { 
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfileClaim>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;


            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberProfileClaim>(modelBuilder, ref order);

            // --------------------------------------------------
            // Indexes:
            modelBuilder.AssignIndex<TenantMemberProfileClaim>(x => x.Authority, false);
            modelBuilder.AssignIndex<TenantMemberProfileClaim>(x => new {x.PrincipalProfileFK, x.Key}, true);
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.PrincipalProfileFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.Authority)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);
            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.AuthoritySignature)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}