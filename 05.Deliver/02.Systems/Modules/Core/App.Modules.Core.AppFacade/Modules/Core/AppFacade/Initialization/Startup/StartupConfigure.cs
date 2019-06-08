using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace App.Modules.Core.AppFacade.Initialization.Startup
{
    public class StartupConfigure : IStartupConfigure
    {
        private readonly IContainer _container;

        public StartupConfigure(IContainer container)
        {
            _container = container;
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Probably in most cases a Module doesn't have to do any 
            // thing specific (all handled by the initial startup.cs file).

            AppendAServiceRegistry();
        }


        /// <summary>
        /// Some ExtensionMethods (eg: AddDbContext)
        /// are expecting a ServiceRegistry (IServiceCollection)
        /// of some kind. 
        /// </summary>
        private void AppendAServiceRegistry()
        {
            ServiceRegistry serviceRegistry = new ServiceRegistry();
            // Your extension method of choice goes here...
            _container.Configure(serviceRegistry);
        }
    }
}
