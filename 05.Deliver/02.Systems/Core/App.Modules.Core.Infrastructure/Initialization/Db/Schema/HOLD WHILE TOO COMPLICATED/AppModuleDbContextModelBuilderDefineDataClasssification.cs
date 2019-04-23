﻿namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using System;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineDataClasssification : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<DataClassification>(modelBuilder);

            var order = 1;

            // Note that this Schema uses an Enum as the Id:
            new UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention()
                .Define<DataClassification, NZDataClassification>(modelBuilder, ref order);

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);
        }

    }
}