// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData
{
    /// <summary>
    ///     Contract for initializing objects
    ///     invoked by a logical Module's
    ///     DbContext during migrations.
    ///     <para>
    ///         Used to set data that is considered
    ///         part of the model (hence in the Migrations)
    ///         that will not change.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Contracts.IHasModuleSpecificInitializer" />
    public interface IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer :
        IHasModuleSpecificInitializer
    {
        /// <summary>
        ///     Invoke to create immutable data
        ///     as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        void DefineImmutableData(ModelBuilder modelBuilder);
    }
}