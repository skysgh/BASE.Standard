﻿using App.Modules.Core.Infrastructure.Constants.Users;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData
{
    using Microsoft.EntityFrameworkCore;
    using static Users;

    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederPrincipal :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {
        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            CreateAnonUser(modelBuilder);
            CreateSystemPrincipal(modelBuilder);
        }

        void CreateAnonUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>().HasData(
            new Principal
            {
                Id = Users.Anon.Id,
                Enabled = true,
                CategoryFK = ((int)PrincipalTypes.Default).ToGuid(),
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
        void CreateSystemPrincipal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Principal>().HasData(
            new Principal
            {
                Id = Users.SysDaemon.Id,
                Enabled = true,
                CategoryFK = ((int)PrincipalTypes.System).ToGuid(),
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