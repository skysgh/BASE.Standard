using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantSecurityProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantSecurityProfileRoleGroup2RoleAssignment : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }


            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantSecurityProfileRoleGroup2RoleAssignment>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenantSecurityProfileRoleGroup2RoleAssignment>()
                 .HasKey(x => new
                 {
                     x.TenantFK,
                     x.GroupFK,
                     x.RoleFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<TenantSecurityProfileRoleGroup2RoleAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenantSecurityProfileRoleGroup2RoleAssignment>(ref order);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantSecurityProfileRoleGroup2RoleAssignment>()
                .Property(x => x.AssignmentType)
                .IsRequired(true);
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantSecurityProfileRoleGroup2RoleAssignment>()
                .Property(x => x.GroupFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired(true);

            modelBuilder.Entity<TenantSecurityProfileRoleGroup2RoleAssignment>()
                    .Property(x => x.RoleFK)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<TenantSecurityProfileRoleGroup2RoleAssignment>()
             .HasOne(x => x.Group)
             .WithMany(x => x.RoleAssignments)
             .HasForeignKey(x => x.GroupFK)
             ;

            modelBuilder.Entity<TenantSecurityProfileRoleGroup2RoleAssignment>()
             .HasOne(x => x.Role)
             .WithMany()
             .HasForeignKey(x => x.RoleFK)
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

