namespace App.Modules.Core.Infrastructure.Db.Schema
{
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services.Implementations;
    using Microsoft.EntityFrameworkCore;

    // A specialised class to define a DbContext model. 
    // It's extracted from the DbContext itself for SOC
    // objectives (when done by manual method, can end up with
    // lots of models, and it gets unwieldy, making DbContext
    // hard to grock.
    public class AppCoreModelBuilderOrchestrator
    {

        public AppCoreModelBuilderOrchestrator()
        {

        }

        //Invoked from CoreModuleDbContext/OnModelCreating
        public void Initialize(ModelBuilder modelBuilder)
        {
            DefineByReflection(modelBuilder);
        }


        private void DefineByReflection(ModelBuilder modelBuilder)
        {
            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.
            DependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextModelBuilderInitializer>()
                .ForEach(x => { if (!(typeof(IHasIgnoreThis).IsAssignableFrom(x.GetType()))) { x.Define(modelBuilder); } });
        }

    }
}