using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Modules.Core.Infrastructure.Data.Db;
using App.Modules.Core.Infrastructure.Initialization.Db;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Initialization.Data.Db.Migrations.Seeding
{
    public class ExampleSeeder : IHasModuleSpecificDbContextSeedInitializer
    {
        public void Seed(ModuleDbContextBase context)
        {
            if (!context.Set<ExceptionRecord>().Any(x => x.Id == 1.ToGuid()))
            {
                SeedExampleRecord(context);
            }
        }

        private void SeedExampleRecord(ModuleDbContextBase context)
        {
            context.AddOrUpdate<ExceptionRecord>(x => x.Id,
                new ExceptionRecord()
                {
                    Id = 1.ToGuid(),
                    Level =  TraceLevel.Info,
                    RecordState = RecordPersistenceState.Active,
                    Stack = "...some stack...",
                    Title = "...sometitle"
                });

            bool hasChanges = context.ChangeTracker.HasChanges();

            context.Add(new ExceptionRecord()
            {
                Id = 2.ToGuid(),
                Level = TraceLevel.Info,
                RecordState = RecordPersistenceState.Active,
                Stack = "...some stack...",
                Title = "...sometitle"
            });

            bool hasChanges2 = context.ChangeTracker.HasChanges();

        }
    }
}
