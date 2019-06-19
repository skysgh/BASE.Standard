using System.Linq;
using App;
using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Seeding.MutableData
{
    /// <summary>
    /// Implementation of a seeder that is optionally
    /// invoked, to seed optional demo data.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData.IHasModuleSpecificDbContextMutableDataSeedingInitializer" />
    public class ExampleSeeder : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {
        /// <summary>
        /// If and when invoked,
        /// seeds the given dbContext with
        /// mutable data (ie, optional/demo data).
        /// </summary>
        /// <param name="context">The context.</param>
        public void SeedMutableData(ModuleDbContextBase context)
        {
            //if (!context.Set<Example>().Any(x => x.Id == 1.ToGuid()))
            //{
            //    SeedExampleRecord(context);
            //}
        }

        private void SeedExampleRecord(ModuleDbContextBase context)
        {
            //context.AddOrUpdate(x => x.Id,
            //    new Example()
            //    {
            //        Id = 1.ToGuid(),
            //        Level = TraceLevel.Info,
            //        Stack = "...some stack...",
            //        Message = "...sometitle"
            //    });

            //bool hasChanges = context.ChangeTracker.HasChanges();

            //context.Add(new ExceptionRecord()
            //{
            //    Id = 2.ToGuid(),
            //    Level = TraceLevel.Info,
            //    Stack = "...some stack...",
            //    Message = "...sometitle"
            //});

            //bool hasChanges2 = context.ChangeTracker.HasChanges();

        }
    }
}
