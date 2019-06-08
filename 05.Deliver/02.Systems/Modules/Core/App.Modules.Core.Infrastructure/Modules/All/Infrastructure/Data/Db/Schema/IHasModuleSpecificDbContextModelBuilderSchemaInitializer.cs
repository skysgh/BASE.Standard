using App.Modules.All.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema
{
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