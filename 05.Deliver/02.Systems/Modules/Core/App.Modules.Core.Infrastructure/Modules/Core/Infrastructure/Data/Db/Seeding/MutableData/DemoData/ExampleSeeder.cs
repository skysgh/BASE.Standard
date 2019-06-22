// Copyright MachineBrains, Inc. 2019

using System.Linq;
using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.MutableData.DemoData
{
    public class ExampleSeeder : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {
        public void SeedMutableData(ModuleDbContextBase context)
        {
            if (!context.Set<ExceptionRecord>().Any(x => x.Id == 1.ToGuid()))
            {
                SeedExampleRecord(context);
            }
        }

        private void SeedExampleRecord(ModuleDbContextBase context)
        {
            context.AddOrUpdate(x => x.Id,
                new ExceptionRecord
                {
                    Id = 1.ToGuid(),
                    Level = TraceLevel.Info,
                    Stack = "...some stack...",
                    Message = "...sometitle"
                });

            var hasChanges = context.ChangeTracker.HasChanges();

            context.Add(new ExceptionRecord
            {
                Id = 2.ToGuid(),
                Level = TraceLevel.Info,
                Stack = "...some stack...",
                Message = "...sometitle"
            });

            var hasChanges2 = context.ChangeTracker.HasChanges();
        }
    }
}