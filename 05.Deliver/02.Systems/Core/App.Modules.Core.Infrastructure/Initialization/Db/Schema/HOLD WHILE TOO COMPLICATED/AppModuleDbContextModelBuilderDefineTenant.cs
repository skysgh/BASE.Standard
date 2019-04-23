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
    public class AppModuleDbContextModelBuilderDefineTenant : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<Tenant>(modelBuilder);

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Tenant>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:



            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<Tenant>()
                .Property(x => x.IsDefault)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"UX_{typeof(Tenant).Name}_IsDefault") {IsUnique = true }))
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired(true);

            modelBuilder.Entity<Tenant>()
                .HasOptional(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Key)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Tenant).Name}_Key") {IsUnique = true}))
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);
            modelBuilder.Entity<Tenant>()
                .Property(x => x.HostName)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Tenant).Name}_HostName") {IsUnique = true}))
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(false);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.DisplayName)
                //.HasColumnOrder(order++)
                .HasColumnAnnotation("Index",
                    new IndexAnnotation(new IndexAttribute($"IX_{typeof(Tenant).Name}_DisplayName") { IsUnique = false }))
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(true);

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Properties)
                .WithOptional()
                .HasForeignKey(x => x.TenantFK);

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Claims)
                .WithOptional()
                .HasForeignKey(x => x.TenantFK);

            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}