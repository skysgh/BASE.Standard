using App.Modules.Core.Shared.Models.Entities.TenancySpecific;

namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineAccountGroup : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<TenantSecurityProfileRoleGroup>(modelBuilder);

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



            modelBuilder.DefineTitleAndDescription<TenantSecurityProfileRoleGroup>(ref order, TextFieldSizes.X64, true, false);

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

