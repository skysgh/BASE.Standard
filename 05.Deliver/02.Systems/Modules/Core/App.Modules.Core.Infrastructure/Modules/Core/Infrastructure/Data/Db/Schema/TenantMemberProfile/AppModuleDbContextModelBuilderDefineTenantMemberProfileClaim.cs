// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Constants.Db.Schemas;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities.TenantMember.Profile;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantMemberProfile
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class
        AppModuleDbContextModelBuilderDefineTenantMemberProfileClaim :
            IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfileClaim>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;


            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberProfileClaim>(
                modelBuilder, ref order);

            // --------------------------------------------------
            // Indexes:
            modelBuilder.AssignIndex<TenantMemberProfileClaim>(x => x.Authority);
            modelBuilder.AssignIndex<TenantMemberProfileClaim>(x => new {x.PrincipalProfileFK, x.Key}, true);
            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.PrincipalProfileFK)
                //.HasColumnOrder(order++)
                .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.Authority)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);
            modelBuilder.Entity<TenantMemberProfileClaim>()
                .Property(x => x.AuthoritySignature)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X2048)
                .IsRequired();

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}