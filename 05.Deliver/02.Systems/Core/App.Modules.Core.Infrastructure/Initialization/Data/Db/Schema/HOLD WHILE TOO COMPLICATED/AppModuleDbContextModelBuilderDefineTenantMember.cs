namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipalProfile : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalProfile>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<PrincipalProfile>()
                .Property(x => x.Enabled)
                .IsRequired(true);

            modelBuilder.Entity<PrincipalProfile>()
                .Property(x => x.EnabledBeginningUtc)
                .IsRequired(false);

            modelBuilder.Entity<PrincipalProfile>()
                .Property(x => x.EnabledEndingUtc)
                .IsRequired(false);

            modelBuilder.Entity<PrincipalProfile>()
                .HasOptional(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<PrincipalProfile>()
               .HasRequired(x => x.Category)
               .WithMany()
               .HasForeignKey(x => x.CategoryFK);

            modelBuilder.Entity<PrincipalProfile>()
                .HasMany(x => x.Properties)
                .WithOptional()
                .HasForeignKey(x => x.PrincipalProfileFK);

            modelBuilder.Entity<PrincipalProfile>()
                .HasMany(x => x.Claims)
                .WithOptional()
                .HasForeignKey(x => x.PrincipalProfileFK);
            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------

        }
    }
}