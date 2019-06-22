// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Contracts;
using App.Modules.All.Infrastructure.Data.Db.Contexts;

namespace App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData
{
    /// <summary>
    ///     Contract for Seeders that are optionally
    ///     invoked, to seed optional demo data.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Contracts.IHasModuleSpecificInitializer" />
    public interface IHasModuleSpecificDbContextMutableDataSeedingInitializer : IHasModuleSpecificInitializer
    {
        /// <summary>
        ///     If and when invoked,
        ///     seeds the given dbContext with
        ///     mutable data (ie, optional/demo data).
        /// </summary>
        /// <param name="context">The context.</param>
        void SeedMutableData(ModuleDbContextBase context);
    }
}