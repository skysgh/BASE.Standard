using System;
using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.Core.Shared.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.ImmutableData
{
    public class ModuleSpecificDbContextModelBuilderImmutableDataSeederExceptionRecord :
        ModuleSpecificDbContextModelBuilderImmutableDataSeederBase
    {

        public override void DefineImmutableData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionRecord>().HasData(
            new ExceptionRecord()
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