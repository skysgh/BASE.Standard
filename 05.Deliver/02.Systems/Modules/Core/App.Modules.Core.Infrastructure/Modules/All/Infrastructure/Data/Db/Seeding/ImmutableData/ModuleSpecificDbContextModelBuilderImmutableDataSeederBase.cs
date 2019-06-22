// Copyright MachineBrains, Inc. 2019

using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData
{
    /// <summary>
    ///     Base class for
    ///     seeding of immutable data
    ///     as part of
    ///     DbContext Migrations.
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData.IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer" />
    public abstract class ModuleSpecificDbContextModelBuilderImmutableDataSeederBase :
        IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer
    {
        /// <summary>
        ///     Invoke to create immutable data
        ///     as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public abstract void DefineImmutableData(ModelBuilder modelBuilder);
    }
}