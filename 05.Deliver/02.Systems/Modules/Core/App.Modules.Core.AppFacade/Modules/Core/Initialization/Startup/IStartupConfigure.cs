using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace App.Modules.Core.Initialization.Startup
{

    /// <summary>
    /// Contract for a class that can be invoked from 
    /// Startup.cs in the host file.
    /// </summary>
    public interface IStartupConfigure 
    {
        void Configure(IApplicationBuilder app, IHostingEnvironment env);
    }

}
