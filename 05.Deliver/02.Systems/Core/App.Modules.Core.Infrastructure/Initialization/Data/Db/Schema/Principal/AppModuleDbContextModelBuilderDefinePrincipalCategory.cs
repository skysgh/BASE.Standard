namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefinePrincipalCategory : IHasAppModuleDbContextModelBuilderInitializer
    {
        public void Define(ModelBuilder modelBuilder)
        {
            var order = 1;

            new DefaultTableAndSchemaNamingConvention().Define<PrincipalCategory>(modelBuilder);

            new UntenantedAuditedRecordStatedTimestampedGuidIdDataConvention().Define<PrincipalCategory>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:

            modelBuilder.DefineDisplayableReferenceData<DataClassification>(ref order);

        }
    }
}