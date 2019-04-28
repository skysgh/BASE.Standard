namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using System.Linq;
    using System.Reflection;
    using App.Modules.Core.Infrastructure.Contracts;
    using App.Modules.Core.Infrastructure.Initialization.Db;
    using App.Modules.Core.Infrastructure.Services.Implementations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class DbContextSchemaModelInitializationService : IDbContextSchemaModelInitializationService
    {
        private readonly IServiceCollection _serviceCollection;

        public DbContextSchemaModelInitializationService(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void DefineByReflection(ModelBuilder modelBuilder, Assembly assemblyToSearchForModelsWithin = null)
        {
            Assembly thisAssembly = this.GetType().DeclaringType.Assembly;


            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.
            var modelBuilderInitializers =
                DependencyLocator.Current.GetAllInstances<IHasAppModuleDbContextModelBuilderInitializer>().ToArray();

            modelBuilderInitializers.ForEach(x =>
            {
                // This base class has the logic that excludes 
                // Models from other Module assemblies:
                if ((assemblyToSearchForModelsWithin != null) && (x.GetType().Assembly != thisAssembly))
                {
                    // Move on to next model builder initializer.
                    return;
                }

                // Some initializers -- usually during testing -- will be ignored:
                if (!(typeof(IHasIgnoreThis).IsAssignableFrom(x.GetType())))
                {
                    x.Define(modelBuilder);
                }
            });

        }
    }
}