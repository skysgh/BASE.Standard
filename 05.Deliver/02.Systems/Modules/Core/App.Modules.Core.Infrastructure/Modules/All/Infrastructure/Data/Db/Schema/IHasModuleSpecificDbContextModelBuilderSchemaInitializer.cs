// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Schema
{
    /// <summary>
    ///     Contract for Db ModelBuilders,
    ///     common to all Modules.
    /// </summary>
    public interface IHasModuleSpecificDbContextModelBuilderSchemaInitializer :
        IHasModuleSpecificInitializer
    {
        /// <summary>
        ///     Defines the Module specific DbContext schema
        ///     for a given entity.
        ///     <para>
        ///         Invoked at startup.
        ///     </para>
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        void DefineSchema(ModelBuilder modelBuilder);
    }
}