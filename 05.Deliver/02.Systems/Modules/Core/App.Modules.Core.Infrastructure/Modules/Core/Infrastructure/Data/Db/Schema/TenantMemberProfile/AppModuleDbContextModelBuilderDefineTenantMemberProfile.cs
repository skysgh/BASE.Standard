using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantMemberProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantMemberProfile : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .Property(x => x.EnabledBeginningUtc)
                .IsRequired(false);

            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .Property(x => x.EnabledEndingUtc)
                .IsRequired(false);

            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
               .HasOne(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryFK);

            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.PrincipalProfileFK);

            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.PrincipalProfileFK);
            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<Shared.Models.Entities.TenantMember.Profile.TenantMemberProfile>()
                .HasOne(x => x.SecurityProfile)
                .WithMany()
                .HasForeignKey(x => x.SecurityProfileFK);

            // --------------------------------------------------
            // Collection Navigation Properties:                               

            // --------------------------------------------------

        }
    }
}