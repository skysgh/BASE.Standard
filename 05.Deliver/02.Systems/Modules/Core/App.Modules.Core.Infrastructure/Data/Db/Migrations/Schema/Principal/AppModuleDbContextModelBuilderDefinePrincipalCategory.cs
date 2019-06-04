using App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Conventions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema.Principal
{
    public class AppModuleDbContextModelBuilderDefinePrincipalCategory : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            var order = 1;

            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalCategory>(
                    modelBuilder,
                    App.Modules.Core.Shared.Constants.ModuleSpecific.Module.Id(this.GetType())
                );

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalCategory>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);

        }
    }
}