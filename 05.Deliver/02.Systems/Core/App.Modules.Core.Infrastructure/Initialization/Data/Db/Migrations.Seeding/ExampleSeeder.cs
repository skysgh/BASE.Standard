using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Modules.Core.Infrastructure.Data.Db;
using App.Modules.Core.Infrastructure.Initialization.Db;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Initialization.Data.Db.Migrations.Seeding
{
    public class ExampleSeeder : IHasAppModuleDbContextSeedInitializer
    {
        public void Seed(ModuleDbContextBase context)
        {
            if (!context.Set<ExceptionRecord>().Any(x => x.Id == 1.ToGuid()))
            {

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

        }
    }
}
