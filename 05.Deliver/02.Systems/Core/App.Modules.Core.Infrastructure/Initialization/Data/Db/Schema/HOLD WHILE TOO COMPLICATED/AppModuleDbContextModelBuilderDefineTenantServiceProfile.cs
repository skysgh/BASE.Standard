namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefineTenantServiceProfile : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalServiceProfile>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalServiceProfile>(modelBuilder, ref order);
            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            //modelBuilder.Entity<TenantServiceProfile>()
            //    .Property(x => x.Enabled)
            //    .IsRequired(true);
            // -----
            modelBuilder.Entity<PrincipalServiceProfile>()
                .HasRequired(x => x.Tenant)
                .WithMany()
                .HasForeignKey(x => x.TenantFK);
            // -----
            //modelBuilder.Entity<TenantServiceProfile>()
            //    .HasMany(x => x.ServicePlans)
            //    .WithOptional()
            //    .HasForeignKey(x => x.OwnerFK);

            //modelBuilder.Entity<TenantServiceProfile>()
            //    .HasMany(x => x.Services)
            //    .WithOptional()
            //    .HasForeignKey(x => x.OwnerFK);



            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            /* See Complex Join Object for Navigation to ServicePlanOfferings collection */

            // --------------------------------------------------


        }
    }
}