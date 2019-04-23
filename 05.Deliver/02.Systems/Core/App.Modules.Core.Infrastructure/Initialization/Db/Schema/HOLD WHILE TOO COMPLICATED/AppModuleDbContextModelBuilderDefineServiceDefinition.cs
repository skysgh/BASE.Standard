namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Constants.Db;
    using App.Modules.Core.Infrastructure.Db.Schema.Conventions;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Shared.Models.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppModuleDbContextModelBuilderDefineServiceDefinition : IHasAppModuleDbContextModelBuilderInitializer
    { 
        public void Define(ModelBuilder modelBuilder)
        {
            new DefaultTableAndSchemaNamingConvention().Define<ServiceDefinition>(modelBuilder);

            var order = 1;

            // --------------------------------------------------
            // Standard Properties:
            new UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataConvention().Define<ServiceDefinition>(modelBuilder, ref order);

            // Note that this Schema uses an Enum as the Id:

            // --------------------------------------------------
            // FK Properties:

            // --------------------------------------------------
            // Model Specific Properties:

            modelBuilder.DefineDisplayableReferenceData<ServiceDefinition>(ref order);

            // --------------------------------------------------
            // Entity Navigation Properties:

            // --------------------------------------------------
            // Collection Navigation Properties:

            // --------------------------------------------------


        }
    }
}