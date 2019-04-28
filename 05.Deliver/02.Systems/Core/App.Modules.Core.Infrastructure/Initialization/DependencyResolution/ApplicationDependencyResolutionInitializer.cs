// Copyright MachineBrains, Inc.

using System;
using System.IO;
using System.Linq;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using App.Modules.Core.Shared.Constants;
using App.Modules.Core.Shared.Contracts;
using Lamar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.Core.Infrastructure.Initialization.DependencyResolution
{

    /// <summary>
    /// Class invoked from UnitTesting to create a DI Container
    /// (ASP.Core does this behind the scenes, whereas UnitTests
    /// have to creat their own).
    /// The class then invokes the same shared Services initializer that
    /// ASP.Core uses.
    /// TODO: Migrations may one day be wired up to use this.
    /// </summary>
    public class ApplicationDependencyResolutionContainerInitializer : IHasInitialize
    {

        /// <summary>
        /// The DI which this Initializer created.
        /// </summary>
        public static Container Container { get; private set; }

        public void Initialize()
        {
            if (Container != null)
            {
                return;
            }

            lock (this)
            {
                var checkDir = Environment.CurrentDirectory;

                // Whereas ASP.Core sets up a Container in the background, 
                // As well as a ServiceRegistry (a 
                // passing it to the Startup.SetupContainer method
                // Unit Testing has to set up it's own Container.
                var serviceRegistry = new ServiceRegistry();

                CreateConfiguration(serviceRegistry);

                // Now that the ServiceRegistry exists, 
                // And patching of what's missing by not using ASP.Core is completed
                // We can use the common methods to scan for Dependencies:
                new ApplicationDependencyResolutionInitializer()
                    .Initialize(serviceRegistry);

                // And use that to Create a new Container (in ASP.CORE
                // this step was all done behind the scenes):
                Container = new Container(serviceRegistry);

                //Register the Container:
                DependencyLocator.Current.Initialize(Container);

                //Proof:
                Container.GetInstance<IDependencyResolutionService>().Initialize(Container);

                // We're done. On to Unit Testing.

                // For diagnostics purposes:
                var s1 = Container.WhatDidIScan();
                var s2 = Container.WhatDoIHave();
            }

        }


        /// <summary>
        /// <para>
        /// Background:
        /// Whereas ASP.Core stuffs the serviceRegistry with IConfiguration,
        /// UnitTesting does not. So have to do this hack.</para>
        /// </summary>
        /// <param name="serviceRegistry"></param>
        private static void CreateConfiguration(ServiceRegistry serviceRegistry)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();

            var check = configuration.GetChildren().Count();

            serviceRegistry.For<IConfiguration>().Add(configuration).Singleton();
        }
    }
    /// <summary>
    ///     Class invoked from
    /// * Startup's ConfigureContainer method (in App.Host)
    /// * UnitTestDependencyInjectionInitializer (in App.Modules.Core.Shared.Tests)
    ///     to initialize all that is not specific to HTML.
    /// </summary>
    public class ApplicationDependencyResolutionInitializer : IHasInitialize<ServiceRegistry>
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
                    x => x.GetName().Name.StartsWith(
                        Application.AssemblyPrefix
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

            //InitializeDependencyLocator(services);
        }


        ///// <summary>
        ///// Service Location is not recommended...but often still required.
        ///// </summary>
        ///// <param name="services"></param>
        //private static void InitializeDependencyLocator(ServiceRegistry services)
        //{
        //    var x = services.BuildServiceProvider();

        //    var serviceProvider = x.GetService<IDependencyResolutionService>().ServiceProvider;

        //    var equal = object.Equals(x, serviceProvider);

        //    services.BuildServiceProvider();

        //    new ServiceCollection().BuildServiceProvider()
        //    Microsoft.Extensions.DependencyInjection..ServiceCollection();


        //    var check = true;
        //    //IServiceProvider serviceProvider = services.BuildServiceProvider();
        //    //App.Modules.Core.Shared.Factories.ServiceLocator.SetLocatorProvider(serviceProvider);
        //}
    }
}