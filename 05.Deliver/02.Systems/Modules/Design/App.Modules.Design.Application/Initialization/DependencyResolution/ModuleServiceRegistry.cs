using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Application.Initialization.DependencyResolution;
using App.Modules.Core.Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.Design.Application.Initialization.DependencyResolution
{
    /// <summary>
    /// Discoverable (by Reflection) Module specific configuration
    /// of the DependencyLocator.
    /// <para>
    /// Note that it is important that these common classes
    /// are just called 'Module'Something and not 'ModuleXXX'Something,
    /// (and just use the Namespace to distinguish between Modules)
    /// so that it is easier to start new development just using Search/Replace
    /// within namespaces (it's easier to find `Module1` within `.Module1`
    /// than find the same thing within `Module1Something`.
    /// </para>
    /// </summary>
    public class ModuleServiceRegistry : ModuleServiceRegistryBase
    {
        public ModuleServiceRegistry() 
        {
            //Reuse base Constructor, which scans this logical Module.
        }
    }
}
