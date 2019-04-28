namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineTenantMemberProfile : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<TenantMemberProfile>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantMemberProfile>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<TenantMemberProfile>()
                .Property(x => x.EnabledBeginningUtc)
                .IsRequired(false);

            modelBuilder.Entity<TenantMemberProfile>()
                .Property(x => x.EnabledEndingUtc)
                .IsRequired(false);

            modelBuilder.Entity<TenantMemberProfile>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<TenantMemberProfile>()
               .HasOne(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryFK);

            modelBuilder.Entity<TenantMemberProfile>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.PrincipalProfileFK);

            modelBuilder.Entity<TenantMemberProfile>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.PrincipalProfileFK);
            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<TenantMemberProfile>()
                .HasOne(x => x.SecurityProfile)
                .WithMany()
                .HasForeignKey(x => x.SecurityProfileFK);

            // --------------------------------------------------
            // Collection Navigation Properties:                               

            // --------------------------------------------------

        }
    }
}