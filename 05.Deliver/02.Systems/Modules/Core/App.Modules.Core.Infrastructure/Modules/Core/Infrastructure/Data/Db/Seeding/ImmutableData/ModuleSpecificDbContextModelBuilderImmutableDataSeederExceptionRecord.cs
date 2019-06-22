// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
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
    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederExceptionRecord :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        ///     Invoke to create immutable data
        ///     as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionRecord>().HasData(
                new ExceptionRecord
                {
                    Id = 1.ToGuid(),
                    Level = TraceLevel.Info,
                    Message = $"Installation of System occurred on: {DateTimeOffset.UtcNow.ToString()}",
                    Stack = ""
                }
            );
        }
    }
}