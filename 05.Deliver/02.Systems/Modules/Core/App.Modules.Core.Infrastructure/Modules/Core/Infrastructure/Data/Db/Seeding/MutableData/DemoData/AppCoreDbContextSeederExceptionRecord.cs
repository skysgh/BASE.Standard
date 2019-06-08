using App.Modules.All.Infrastructure.Data.Db.Contexts;
using App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Infrastructure.Data.Db.Seeding.MutableData.DemoData
{
    /// <summary>
    /// Seeder invoked by <see cref="ModuleDbContextSeedingOrchestrator"/>
    /// </summary>
    /// <seealso cref="IHasModuleSpecificDbContextMutableDataSeedingInitializer" />
    public class CoreModuleDbContextSeederExceptionRecord : IHasModuleSpecificDbContextMutableDataSeedingInitializer
    {

        public void SeedMutableData(ModuleDbContextBase moduleDbContext)
        {
            var records = new []{
                    new ExceptionRecord()
                    {
                        Id = 2.ToGuid(),
                        Level = TraceLevel.Warn,
                        Message="Demo Warning",
                        Stack = "blah...."
                    },
                new ExceptionRecord()
                {
                    Id = 3.ToGuid(),
                    Level = TraceLevel.Error,
                    Message="Demo Error",
                    Stack = "blah again...."
                },
            };

            moduleDbContext.Set<ExceptionRecord>().AddOrUpdateBasedOnId(records);
            moduleDbContext.SaveChanges();
        }
    }
}