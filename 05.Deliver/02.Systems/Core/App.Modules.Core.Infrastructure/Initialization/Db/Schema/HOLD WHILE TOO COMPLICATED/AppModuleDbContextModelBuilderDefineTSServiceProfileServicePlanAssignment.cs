namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefineTenantServiceProfileServicePlanAllocation : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalServiceProfileServicePlanAllocation>(modelBuilder);

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);


            //// --------------------------------------------------
            //// Create Table Name:
            //modelBuilder.Entity<TenantServiceProfileServiceOfferingAllocation>()
            //    .ToTable(
            //        $"{typeof(TenantServiceProfile)}__{typeof(ServicePlanDefinition)}"
            //    );
            // --------------------------------------------------

            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.TenantServiceProfileFK,
                     x.ServicePlanFK
                 });
            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:

            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention()
                .Define< PrincipalServiceProfileServicePlanAllocation>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                .Property(x => x.TenantServiceProfileFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired(true);

            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                    .Property(x => x.ServicePlanFK)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                    .Property(x => x.Enabled)
                    //.HasColumnOrder(order++)
                    .IsRequired(true);

            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                    .Property(x => x.ServicePlanQuantity)
                    //.HasColumnOrder(order++)
                    .IsRequired(true);


            // --------------------------------------------------
            // Entity Navigtation Properties:

            // Navigation from parent to this 
            // IMPORTANT: (notice T = Parent object, not this object)
            modelBuilder.Entity<PrincipalServiceProfile>()
                .HasMany(x => x.ServicePlans)
                .WithOne(/*no navigation from Join Object to Parent*/)
                .HasForeignKey(x => x.TenantServiceProfileFK);

            // Navigate from here to to the child Object, 
            // without offering a means to navigate back up to this 
            // Complex, Join Object or the parent:
            modelBuilder.Entity<PrincipalServiceProfileServicePlanAllocation>()
                 .HasRequired(x => x.ServicePlan)
                 // Notice how on the other side we are not specifying any collection:
                 .WithMany()
                 .HasForeignKey(x => x.ServicePlanFK)
                 ;
            // --------------------------------------------------
            // Collection Navigation Properties:


            // --------------------------------------------------
        }
    }


}

