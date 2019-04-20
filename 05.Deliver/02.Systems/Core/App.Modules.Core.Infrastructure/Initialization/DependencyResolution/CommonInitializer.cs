using Lamar;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Infrastructure.Initialization.DependencyResolution
{
    /// <summary>
    /// Class invoked from App.Host Startup,
    /// to initialize all that is not specific 
    /// to HTML.
    /// </summary>
    public class CommonInitializer 
    {

        public void Initialize(ServiceRegistry services)
        {
            services.Scan(assemblyScanner =>
            {
                // Note that this is the true base registry 
                // (whereas the Controllers may not be relevant here)

                //Where we want to be:
                // Want this scanner to search in all Assemblies related to this system.
                // Which we can see from the dll's name (as long as everybody
                // sticks to the convention of "App...." 
                assemblyScanner.AssembliesFromApplicationBaseDirectory(
                    x => x.GetName().Name.StartsWith(
                        App.Modules.Core.Shared.Constants.Application.APPPREFIX
                    ));

                // Scan across all known assemblies for Services, Factories, etc.
                // That meet ISomething => Something naming convention:
                assemblyScanner.WithDefaultConventions();

                //This ensures it looks for additional Registries beyond this
                // Core one. In other words, it will scan all known assemblies 
                // (as per first line) for Module specific Registries. Such 
                // as AppModuleRegistry.
                assemblyScanner.LookForRegistries();
            });

            //// Inline invocation of *main* registry (this is just a wrapper, really)
            //// that can be invoked from here (runtime html specific), 
            //// or via unit tests
            //services.IncludeRegistry<AppAllInfrastructureRegistry>();

            InitializeServiceLocator(services);
        }


        /// <summary>
        /// Service Location is not recommended...but often still required.
        /// </summary>
        /// <param name="services"></param>
        private static void InitializeServiceLocator(ServiceRegistry services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            //App.Modules.Core.Shared.Factories.ServiceLocator.SetLocatorProvider(serviceProvider);
        }
    }
}
