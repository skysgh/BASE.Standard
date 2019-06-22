// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Tenants
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineTenant : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Tenant>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Tenant>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:


            // --------------------------------------------------
            // Model Specific Properties:
            //modelBuilder.AssignIndex<Tenant>(x => x.IsDefault,true);
            modelBuilder.AssignIndex<Tenant>(x => x.Key);
            //modelBuilder.AssignIndex<Tenant>(x => x.HostName, true);
            modelBuilder.AssignIndex<Tenant>(x => x.DisplayName);


            modelBuilder.Entity<Tenant>()
                .Property(x => x.IsDefault)
                //.HasColumnOrder(order++)
                .IsRequired(false);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Enabled)
                //.HasColumnOrder(order++)
                .IsRequired();

            modelBuilder.Entity<Tenant>()
                .HasOne(x => x.DataClassification)
                .WithMany()
                .HasForeignKey(x => x.DataClassificationFK);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<Tenant>()
                .Property(x => x.HostName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired(false);

            modelBuilder.Entity<Tenant>()
                .Property(x => x.DisplayName)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Properties)
                .WithOne()
                .HasForeignKey(x => x.TenantFK);

            modelBuilder.Entity<Tenant>()
                .HasMany(x => x.Claims)
                .WithOne()
                .HasForeignKey(x => x.TenantFK);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}