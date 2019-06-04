using System;
using App.Modules.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.ImmutableData
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