namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using Microsoft.EntityFrameworkCore;
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;

    public class AppModuleDbContextModelBuilderDefineTenantMemberCategory : IHasAppModuleDbContextModelBuilderInitializer
    { 
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<PrincipalProfileCategory>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalProfileCategory>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:
            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            // --------------------------------------------------
            // Entity Navigtation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}