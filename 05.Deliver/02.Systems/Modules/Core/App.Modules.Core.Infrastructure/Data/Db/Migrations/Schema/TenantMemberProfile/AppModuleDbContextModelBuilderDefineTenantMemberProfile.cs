using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantMemberProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantMemberProfile : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Models.Entities.TenantMember.Profile.TenantMemberProfile>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Models.Entities.TenantMember.Profile.TenantMemberProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .Property(x => x.EnabledBeginningUtc)
                .IsRequired(false);

            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .Property(x => x.EnabledEndingUtc)
                .IsRequired(false);

            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
               .HasOne(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryFK);

            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.PrincipalProfileFK);

            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.PrincipalProfileFK);
            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasOne(x => x.SecurityProfile)
                .WithMany()
                .HasForeignKey(x => x.SecurityProfileFK);

            // --------------------------------------------------
            // Collection Navigation Properties:                               

            // --------------------------------------------------

        }
    }
}