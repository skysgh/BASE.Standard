// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantMemberSecurityProfile
{
    public class
        AppModuleDbContextModelBuilderDefineTenantMemberSecurityProfile2PermissionsAssignment :
            IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }


            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberSecurityProfile2PermissionAssignment>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenantMemberSecurityProfile2PermissionAssignment>()
                .HasKey(x => new
                {
                    x.TenantFK,
                    x.MemberFK,
                    x.PermissionFK
                });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention()
                .Define<TenantMemberSecurityProfile2PermissionAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenantMemberSecurityProfile2PermissionAssignment>(ref order);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantMemberSecurityProfile2PermissionAssignment>()
                .Property(x => x.AssignmentType)
                .IsRequired();
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantMemberSecurityProfile2PermissionAssignment>()
                .Property(x => x.MemberFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired();

            modelBuilder.Entity<TenantMemberSecurityProfile2PermissionAssignment>()
                .Property(x => x.PermissionFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired();

            // --------------------------------------------------
            // Entity Navigation Properties:
            modelBuilder.Entity<TenantMemberSecurityProfile2PermissionAssignment>()
                .HasOne(x => x.Member)
                .WithMany(x => x.PermissionsAssignments)
                .HasForeignKey(x => x.MemberFK)
                ;

            modelBuilder.Entity<TenantMemberSecurityProfile2PermissionAssignment>()
                .HasOne(x => x.Permission)
                .WithMany() // To many people assigned permissions...
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