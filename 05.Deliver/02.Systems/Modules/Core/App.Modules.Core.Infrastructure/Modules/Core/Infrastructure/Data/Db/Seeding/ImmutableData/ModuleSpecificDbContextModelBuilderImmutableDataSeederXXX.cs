// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.ImmutableData
{
    /// <summary>
    ///     Class for
    ///     seeding of immutable data
    ///     as part of
    ///     DbContext Migrations.
    /// </summary>
    /// <seealso
    ///     cref="App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData.ModuleSpecificDbContextModelBuilderImmutableDataSeederBase" />
    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederXXX :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        ///     Invoke to create immutable data
        ///     as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<XXX>().HasData(
            //    );
        }
    }
}