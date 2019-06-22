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
    public class
        AppModuleDbContextModelBuilderDefineTenantClaim : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantClaim>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantClaim>(modelBuilder,
                ref order);

            // --------------------------------------------------
            // FK Indexes:
            modelBuilder.AssignIndex<TenantClaim>(x => x.Authority);
            modelBuilder.AssignIndex<TenantClaim>(x => x.Key);
            // --------------------------------------------------
            // FK Properties:

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.TenantFK)
                //.HasColumnOrder(order++)
                .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Authority)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();
            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);

            modelBuilder.Entity<TenantClaim>()
                .Property(x => x.AuthoritySignature)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired();

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}