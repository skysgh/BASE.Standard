using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Data
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
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            var order = 1;

            // Note that this Schema uses an Enum as the Id:
            new UntenantedAuditedRecordStatedTimestampedCustomIdDataConvention()
                .Define<DataClassification, NZDataClassification>(modelBuilder, ref order);

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);
        }

    }
}