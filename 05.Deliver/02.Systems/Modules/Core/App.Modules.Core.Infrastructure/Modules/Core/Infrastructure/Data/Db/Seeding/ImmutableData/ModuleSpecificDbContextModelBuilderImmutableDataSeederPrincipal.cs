﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Infrastructure.Constants.Users;
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
    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederPrincipal :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        /// <summary>
        ///     Invoke to create immutable data
        ///     as part of the current Migration.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            CreateAnonUser(modelBuilder);
            CreateSystemPrincipal(modelBuilder);
        }

        private void CreateAnonUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>().HasData(
                new Principal
                {
                    Id = Users.Anon.Id,
                    Enabled = true,
                    DataClassificationFK = NZDataClassification.Unclassified,
                    CategoryFK = ((int) PrincipalTypes.Default).ToGuid(),
                    DisplayName = Users.Anon.Name
                }
            );

            modelBuilder.Entity<PrincipalProperty>().HasData(
                new PrincipalProperty
                {
                    Id = Users.Anon.Id,
                    PrincipalFK = Users.Anon.Id,
                    RecordState = RecordPersistenceState.Active,
                    Key = "Description",
                    Value = "Principal shared by all unauthenticated users, but with distinct Sessions."
                });
        }

        private void CreateSystemPrincipal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>().HasData(
                new Principal
                {
                    Id = Users.SysDaemon.Id,
                    Enabled = true,
                    CategoryFK = ((int) PrincipalTypes.System).ToGuid(),
                    DisplayName = Users.Anon.Name
                }
            );


            modelBuilder.Entity<PrincipalProperty>().HasData(
                new PrincipalProperty
                {
                    Id = 1.ToGuid(),
                    PrincipalFK = Users.Anon.Id,
                    RecordState = RecordPersistenceState.Active,
                    Key = "FavoriteSong",
                    Value = "https://www.youtube.com/watch?v=B1BdQcJ2ZYY"
                },
                new PrincipalProperty
                {
                    Id = 2.ToGuid(),
                    PrincipalFK = Users.Anon.Id,
                    RecordState = RecordPersistenceState.Active,
                    Key = "Seeking",
                    Value = "Romance (what?! You think computers can't dream?!)."
                }
            );
        }
    }
}