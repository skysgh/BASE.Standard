using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;

namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineAccountPermissionAssignment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>(modelBuilder);

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>()
                 .HasKey(x => new
                 {
                     // x.TenantFK
                     x.AccountFK,
                     x.PermissionFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>(ref order);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>()
                .Property(x => x.AccountFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired(true);

            modelBuilder.Entity<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>()
                    .Property(x => x.PermissionFK)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);
            // --------------------------------------------------
            modelBuilder.Entity<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>()
                    .Property(x => x.AssignmentType)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigtation Properties:
            modelBuilder.Entity<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>()
             .HasRequired(x => x.Account)
             .WithMany(x => x.PermissionsAssignments)
             .HasForeignKey(x => x.AccountFK)
             ;

            modelBuilder.Entity<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>()
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

