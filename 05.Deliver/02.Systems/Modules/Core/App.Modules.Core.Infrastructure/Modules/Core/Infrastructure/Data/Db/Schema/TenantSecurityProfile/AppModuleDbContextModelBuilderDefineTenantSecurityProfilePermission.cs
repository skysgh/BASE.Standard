﻿using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.TenantSecurityProfile
{
    public class AppModuleDbContextModelBuilderDefineTenantSecurityProfilePermission : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<TenantSecurityProfilePermission>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new TenantFKAuditedRecordStatedTimestampedGuidIdDataConvention()
                .Define<TenantSecurityProfilePermission>(modelBuilder, ref order);


            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:
            // At present it is a sparse ReferenceData, with no enabled, no display information.
            modelBuilder.DefineTitleAndDescription<TenantSecurityProfilePermission>(ref order);


            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // No navigation from Permission back to Role or Account
            // to which they are associated.
            // --------------------------------------------------
        }

    }
}
