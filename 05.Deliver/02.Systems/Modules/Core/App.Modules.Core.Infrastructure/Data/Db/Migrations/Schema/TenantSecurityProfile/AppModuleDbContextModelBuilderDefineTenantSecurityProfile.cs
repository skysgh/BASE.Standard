using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.TenantSecurityProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantSecurityProfile : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Models.Entities.TenantSecurityProfile>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention().Define<Models.Entities.TenantSecurityProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.


            modelBuilder.DefineTitleAndDescription<Models.Entities.TenantSecurityProfile>(ref order);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
  
        }

    }
}

