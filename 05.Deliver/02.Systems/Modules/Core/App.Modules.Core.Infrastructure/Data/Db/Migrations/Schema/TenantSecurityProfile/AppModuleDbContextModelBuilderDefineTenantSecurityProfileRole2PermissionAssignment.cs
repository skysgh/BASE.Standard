using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantSecurityProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantSecurityProfileRole2PermissionAssignment : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }

            
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantSecurityProfileRole2PermissionAssignment>(modelBuilder
                    ,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenantSecurityProfileRole2PermissionAssignment>()
                 .HasKey(x => new
                 {
                     x.TenantFK,
                     x.RoleFK,
                     x.PermissionFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<TenantSecurityProfileRole2PermissionAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenantSecurityProfileRole2PermissionAssignment>(ref order);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantSecurityProfileRole2PermissionAssignment>()
                .Property(x => x.AssignmentType)
                .IsRequired(true);
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantSecurityProfileRole2PermissionAssignment>()
                .Property(x => x.RoleFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired(true);

            modelBuilder.Entity<TenantSecurityProfileRole2PermissionAssignment>()
                    .Property(x => x.PermissionFK)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<TenantSecurityProfileRole2PermissionAssignment>()
             .HasOne(x => x.Role)
             .WithMany(x => x.PermissionsAssignments)
             .HasForeignKey(x => x.RoleFK)
             ;

            modelBuilder.Entity<TenantSecurityProfileRole2PermissionAssignment>()
             .HasOne(x => x.Permission)
             .WithMany()
             .HasForeignKey(x => x.PermissionFK)
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

