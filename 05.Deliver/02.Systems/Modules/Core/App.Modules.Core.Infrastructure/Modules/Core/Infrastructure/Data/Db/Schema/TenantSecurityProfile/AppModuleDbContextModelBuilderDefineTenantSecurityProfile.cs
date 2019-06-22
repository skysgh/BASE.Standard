// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantSecurityProfile
{
    public class
        AppModuleDbContextModelBuilderDefineTenantSecurityProfile :
            IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<Shared.Models.Entities.TenantSecurityProfile>(
                    modelBuilder,
                    Module.Id(GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<Shared.Models.Entities.TenantSecurityProfile>(modelBuilder, ref order);

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.


            modelBuilder.DefineTitleAndDescription<Shared.Models.Entities.TenantSecurityProfile>(ref order);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:
        }
    }
}