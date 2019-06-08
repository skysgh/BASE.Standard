// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Initialization;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.All.Infrastructure.DependencyResolution
{
    /// <summary>
    ///     Class invoked from
    /// * Startup's ConfigureContainer method (in App.Host)
    /// * UnitTestDependencyInjectionInitializer (in App.Modules.Core.Shared.Tests)
    ///     to initialize all that is not specific to HTML.
    /// </summary>
    public class AllModulesDependencyResolutionInitializer : IHasInitialize<ServiceRegistry>
    {
        public void Initialize(ServiceRegistry services)
        {

            // This will of course depend on whether we are coming in from one of:
            // * the app, hosted in a web server
            // * the unit tests
            // TODO: Not yet able to invoke when coming in from design time creation of Migrations
            // unless the Factory is supposed to initialize Container.
            var currentDirectory = Environment.CurrentDirectory;

            services.AddLogging();

            services.Scan(assemblyScanner =>
            {
                // Note that this is the true base registry 
                // (whereas the Controllers may not be relevant here)

                //Where we want to be:
                // Want this scanner to search in all Assemblies related to this system.
                // Which we can see from the dll's name (as long as everybody
                // sticks to the convention of "App...." 
                assemblyScanner.AssembliesFromApplicationBaseDirectory(
                    x => x.IsSameApp());

                // Scan across all known assemblies for Services, Factories, etc.
                // That meet ISomething => Something naming convention:
                assemblyScanner.WithDefaultConventions();

                //This ensures it looks for additional Registries beyond this
                // Core one. In other words, it will scan all known assemblies 
                // (as per first line) for Module specific Registries. Such 
                // as AppModuleRegistry.


                assemblyScanner.LookForRegistries();
            });

        }

    }
}