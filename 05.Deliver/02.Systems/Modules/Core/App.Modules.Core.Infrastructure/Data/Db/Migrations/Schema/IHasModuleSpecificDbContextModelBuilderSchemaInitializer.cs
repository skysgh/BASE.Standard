using App.Modules.Core.Infrastructure.Initialization;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Schema
{
    using App.Modules.Core.Shared.Contracts;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Contract for Db ModelBuilders,
    /// common to all Modules.
    /// </summary>
    public interface IHasModuleSpecificDbContextModelBuilderSchemaInitializer :
        IHasModuleSpecificInitializer
    {
        void DefineSchema(ModelBuilder modelBuilder);
    }

}