using System.Linq;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Seeding.MutableData.DemoData
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
            context.AddOrUpdate<ExceptionRecord>(x => x.Id,
                new ExceptionRecord()
                {
                    Id = 1.ToGuid(),
                    Level =  TraceLevel.Info,
                    Stack = "...some stack...",
                    Message = "...sometitle"
                });

            bool hasChanges = context.ChangeTracker.HasChanges();

            context.Add(new ExceptionRecord()
            {
                Id = 2.ToGuid(),
                Level = TraceLevel.Info,
                Stack = "...some stack...",
                Message = "...sometitle"
            });

            bool hasChanges2 = context.ChangeTracker.HasChanges();

        }
    }
}
