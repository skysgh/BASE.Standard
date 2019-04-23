namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineRolePermissionAssignment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }

            new DefaultTableAndSchemaNamingConvention().Define<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>(modelBuilder);

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.RoleFK,
                     x.PermissionFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>(ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
                .Property(x => x.RoleFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired(true);

            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
                    .Property(x => x.PermissionFK)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigtation Properties:
            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
             .HasRequired(x => x.Role)
             .WithMany(x => x.PermissionsAssignments)
             .HasForeignKey(x => x.RoleFK)
             ;

            modelBuilder.Entity<TenancySecurityProfileRoleTenancySecurityProfilePermissionAssignment>()
             .HasRequired(x => x.Permission)
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

