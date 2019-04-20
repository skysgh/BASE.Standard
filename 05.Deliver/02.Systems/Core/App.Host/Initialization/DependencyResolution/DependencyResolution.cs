using App.Modules.Core.Infrastructure.Initialization.DependencyResolution;
using Lamar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Host.Initialization.DependencyResolution
{
    /// <summary>
    /// Invoked by Startup.ps' ConfigureContainer method
    /// to configure Lamar dependency resolution service.
    /// </summary>
    public class DependencyResolution
    {

        public static void Initialize(ServiceRegistry serviceRegistry)
        {
            serviceRegistry.AddLogging();

            serviceRegistry.AddMvc()
                .AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                ;

            //All initialization up to this point was specific to HTML
            // The rest can be moved down to a lower assembly that doesn't have
            // any Reference dependency on HTML.
            // This is so that UnitTesting can take advantage of the same setup:
            new CommonInitializer().Initialize(serviceRegistry);




        }

    }
}
