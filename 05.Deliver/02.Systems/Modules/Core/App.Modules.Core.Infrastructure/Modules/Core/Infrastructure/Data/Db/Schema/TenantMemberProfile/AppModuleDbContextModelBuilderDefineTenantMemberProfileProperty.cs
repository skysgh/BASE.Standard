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
        AppModuleDbContextModelBuilderDefineTenantMemberProfileProperty :
            IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfileProperty>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;


            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberProfileProperty>(
                modelBuilder, ref order);


            // --------------------------------------------------
            // Indexes:
            modelBuilder.AssignIndex<TenantMemberProfileProperty>(x => new {x.PrincipalProfileFK, x.Key}, true);

            // --------------------------------------------------
            // FK Properties:
            modelBuilder.Entity<TenantMemberProfileProperty>()
                .Property(x => x.PrincipalProfileFK)
                //.HasColumnOrder(order++)
                .IsRequired();

            // --------------------------------------------------
            // Model Specific Properties:
            modelBuilder.Entity<TenantMemberProfileProperty>()
                .Property(x => x.Key)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X64)
                .IsRequired();

            modelBuilder.Entity<TenantMemberProfileProperty>()
                .Property(x => x.Value)
                //.HasColumnOrder(order++)
                .HasMaxLength(TextFieldSizes.X1024)
                .IsRequired(false);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}