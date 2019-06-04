using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Entities.TenantMember.Profile;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantMemberProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantMemberProfileCategory : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    { 
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantMemberProfileCategory>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<TenantMemberProfileCategory>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:
            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------
        }
    }
}