// Copyright MachineBrains, Inc. 2019

using System.Linq;
using System.Reflection;
using App.Modules.All.Infrastructure.Contracts;
using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.Core.Infrastructure.DependencyResolution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    public class DbContextSchemaModelInitializationService : IDbContextSchemaModelInitializationService
    {
        private readonly IServiceCollection _serviceCollection;

        public DbContextSchemaModelInitializationService(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void DefineByReflection(ModelBuilder modelBuilder, Assembly assemblyToSearchForModelsWithin = null)
        {
            var thisAssembly = GetType().DeclaringType.Assembly;


            // You can initialize manually or by Convention over Configuration
            // using a combination of common interface and reflection.
            IHasModuleSpecificDbContextModelBuilderSchemaInitializer[] modelBuilderInitializers =
                DependencyLocator.Current.GetAllInstances<IHasModuleSpecificDbContextModelBuilderSchemaInitializer>()
                    .ToArray();

            modelBuilderInitializers.ForEach(x =>
            {
                // This base class has the logic that excludes 
                // Models from other Module assemblies:
                if (assemblyToSearchForModelsWithin != null && x.GetType().Assembly != thisAssembly)
                {
                    // Move on to next model builder initializer.
                    return;
                }

                // Some initializers -- usually during testing -- will be ignored:
                if (!typeof(IHasIgnoreThis).IsAssignableFrom(x.GetType()))
                {
                    x.DefineSchema(modelBuilder);
                }
            });
        }
    }
}