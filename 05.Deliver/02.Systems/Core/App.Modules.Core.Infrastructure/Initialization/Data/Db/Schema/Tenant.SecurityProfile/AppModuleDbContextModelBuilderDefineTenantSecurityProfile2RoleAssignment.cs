﻿using App.Modules.Core.Shared.Models.Entities.TenancySpecific;

namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineTenantSecurityProfile2RoleAssignment : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }

            
            new DefaultTableAndSchemaNamingConvention().Define<TenantSecurityProfile2RoleAssignment>(modelBuilder);

            var order = 1;

            // NO! new TenantFKAuditedTimestampedRecordStatedGuidIdDataConvention().Define<CourseInstructorRole>(modelBuilder, ref order ...no...);

            // --------------------------------------------------
            // Create Composite Index:
            // See: https://stackoverflow.com/a/9960987
            modelBuilder.Entity<TenantSecurityProfile2RoleAssignment>()
                 .HasKey(x => new
                 {
                     x.TenantFK,
                     x.ProfileFK,
                     x.RoleFK
                 });


            // --------------------------------------------------
            // Standard Properties:

            // Re/Do the usual columns:
            new UntenantedAuditedRecordStatedTimestampedNoIdDataConvention().Define<TenantSecurityProfile2RoleAssignment>(modelBuilder, ref order);

            // Add the tenancy:
            modelBuilder.DefineTenantFK<TenantSecurityProfile2RoleAssignment>(ref order);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantSecurityProfile2RoleAssignment>()
                .Property(x => x.AssignmentType)
                .IsRequired(true);
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantSecurityProfile2RoleAssignment>()
                .Property(x => x.ProfileFK)
                //.HasColumnOrder(order++)
                .ValueGeneratedNever()
                .IsRequired(true);

            modelBuilder.Entity<TenantSecurityProfile2RoleAssignment>()
                    .Property(x => x.RoleFK)
                    //.HasColumnOrder(order++)
                    .ValueGeneratedNever()
                    .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigtation Properties:
            modelBuilder.Entity<TenantSecurityProfile2RoleAssignment>()
             .HasOne(x => x.Profile)
             .WithMany(x => x.RoleAssignents)
             .HasForeignKey(x => x.ProfileFK)
             ;

            modelBuilder.Entity<TenantSecurityProfile2RoleAssignment>()
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

