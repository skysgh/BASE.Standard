﻿namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System.ComponentModel.DataAnnotations.Schema;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineTenantClaim : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<TenantClaim>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantClaim>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.TenantFK)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Authority)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(TenantClaim).Name}_Authority") { IsUnique = false }))
                .IsRequired(true);
            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(TenantClaim).Name}_Key") { IsUnique = false }))
                .IsRequired(true);

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.AuthoritySignature)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(true);

            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}