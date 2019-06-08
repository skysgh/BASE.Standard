using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Schema.Conventions;
using App.Modules.All.Shared.Constants;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Schema.Principal
{
    public class AppModuleDbContextModelBuilderDefinePrincipalCategory : IHasModuleSpecificDbContextModelBuilderSchemaInitializer
    {
        public void DefineSchema(ModelBuilder modelBuilder)
        {
            var order = 1;

            new DefaultTableAndSchemaNamingConvention()
                .Define<PrincipalCategory>(
                    modelBuilder,
                    Module.Id(this.GetType())
                );

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalCategory>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);

        }
    }
}