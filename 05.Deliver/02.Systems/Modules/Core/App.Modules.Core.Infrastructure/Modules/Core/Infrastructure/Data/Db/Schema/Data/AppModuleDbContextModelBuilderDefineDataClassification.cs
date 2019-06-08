using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Data
{
    // A single DbContext Entity model map, 
    // invoked via a Module's specific DbContext ModelBuilderOrchestrator
    public class AppModuleDbContextModelBuilderDefineDataClassification : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention()
                .Define<DataClassification>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            var order = 1;

            // Note that this Schema uses an Enum as the Id:
            new UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention()
                .Define<DataClassification, NZDataClassification>(modelBuilder, ref order);

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);
        }

    }
}