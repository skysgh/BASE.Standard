﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.Initialization;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace App.Modules.Core.AppFacade.Initialization
{
    /// <summary>
    /// </summary>
    /// <seealso cref="IStartupConfigure" />
    public class StartupConfigure : IStartupConfigure
    {
        private readonly IContainer _container;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StartupConfigure" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public StartupConfigure(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        ///     Invoke from the Startup.cs in the Host app.
        ///     Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Probably in most cases a Module doesn't have to do any 
            // thing specific (all handled by the initial startup.cs file).

            AppendAServiceRegistry();
        }


        /// <summary>
        ///     Some ExtensionMethods (eg: AddDbContext)
        ///     are expecting a ServiceRegistry (IServiceCollection)
        ///     of some kind.
        /// </summary>
        private void AppendAServiceRegistry()
        {
            var serviceRegistry = new ServiceRegistry();
            // Your extension method of choice goes here...
            _container.Configure(serviceRegistry);
        }
    }
}