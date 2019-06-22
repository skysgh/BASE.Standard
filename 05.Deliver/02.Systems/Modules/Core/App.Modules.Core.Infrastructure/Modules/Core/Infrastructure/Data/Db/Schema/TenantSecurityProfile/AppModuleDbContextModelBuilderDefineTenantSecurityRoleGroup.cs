// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantSecurityProfile
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class
        AppModuleDbContextModelBuilderDefineAccountGroup : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantSecurityProfileRoleGroup>(
                    modelBuilder,
                    Module.Id(GetType())
                );


            var order = 1;
            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<TenantSecurityProfileRoleGroup>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:


            modelBuilder.Entity<TenantSecurityProfileRoleGroup>()
                .Property(x => x.ParentFK)
                //.HasColumnOrder(order++)
                .IsRequired(false);


            modelBuilder.DefineTitleAndDescription<TenantSecurityProfileRoleGroup>(ref order);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
            //modelBuilder.Entity<TenantSecurityProfileRoleGroup>()
            //.HasOne(x => x.Parent)
            //.WithMany(x => x.Groups)
            //.HasForeignKey(x => x.ParentFK)
            //// When you delete this Property (Parent), 
            //// you don't delete every child, so:
            //.OnDelete(De)
            //.WillCascadeOnDelete(false);


            // --------------------------------------------------
        }
    }
}