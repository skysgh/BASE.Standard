﻿// Copyright MachineBrains, Inc.

using System;
using System.IO;
using System.Linq;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Services.Implementations;
using App.Modules.Core.Shared.Contracts;
using Lamar;
using Microsoft.Extensions.Configuration;

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
                new AllModulesDependencyResolutionInitializer()
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
}