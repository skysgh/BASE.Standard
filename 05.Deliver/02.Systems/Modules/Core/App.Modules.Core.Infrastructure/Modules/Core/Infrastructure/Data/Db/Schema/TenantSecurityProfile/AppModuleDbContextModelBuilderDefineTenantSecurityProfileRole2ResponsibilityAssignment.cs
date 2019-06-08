using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantSecurityProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantSecurityProfileRole2ResponsibilityAssignment : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }

            
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantSecurityProfileRole2ResponsibilityAssignment>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenantSecurityProfileRole2ResponsibilityAssignment>()
                 .HasKey(x => new
                 {
                     x.TenantFK,
                     x.RoleFK,
                     x.ResponsibilityFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<TenantSecurityProfileRole2ResponsibilityAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenantSecurityProfileRole2ResponsibilityAssignment>(ref order);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantSecurityProfileRole2ResponsibilityAssignment>()
                .Property(x => x.AssignmentType)
                .IsRequired(true);
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantSecurityProfileRole2ResponsibilityAssignment>()
                .Property(x => x.RoleFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired(true);

            modelBuilder.Entity<TenantSecurityProfileRole2ResponsibilityAssignment>()
                    .Property(x => x.ResponsibilityFK)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<TenantSecurityProfileRole2ResponsibilityAssignment>()
             .HasOne(x => x.Role)
             .WithMany(x => x.ResponsibilityAssignments)
             .HasForeignKey(x => x.RoleFK)
             ;

            modelBuilder.Entity<TenantSecurityProfileRole2ResponsibilityAssignment>()
             .HasOne(x => x.Responsibility)
             .WithMany()
             .HasForeignKey(x => x.ResponsibilityFK)
             ;

            // --------------------------------------------------
            // Collection Navigation Properties:

            //// Do not define these Entity Navigation Properties here, 
            //// as the Collection Navigation Properties
            //// are defined in the other objects.




            // --------------------------------------------------
        }
    }


}

