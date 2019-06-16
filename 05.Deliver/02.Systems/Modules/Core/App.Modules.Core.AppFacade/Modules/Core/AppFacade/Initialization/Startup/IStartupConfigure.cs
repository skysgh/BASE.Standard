using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace App.Modules.Core.AppFacade.Initialization.Startup
{

    /// <summary>
    /// Contract for a class that can be invoked from 
    /// Startup.cs in the host file.
    /// </summary>
    public interface IStartupConfigure 
    {
        /// <summary>
        /// Invoke from the Startup.cs in the Host app.
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        void Configure(IApplicationBuilder app, IHostingEnvironment env);
    }

}
