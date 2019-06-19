// Copyright MachineBrains, Inc.

using App.Modules.All.Infrastructure.DependencyResolution;
using Lamar;
using Lamar.Scanning.Conventions;

namespace App.Modules.All.Application.DependencyResolution
{
    /// <summary>
    /// The base class for each Module's (Core, Module1, Module2, etc.) ServiceRegistry.
    /// <para>
    /// To avoid undesired side effects, It's important that each Module
    /// inherits from this Module as it is set up to only search for dependencies
    /// within this Module's group of assemblies (it's filtering on the Assembly name)
    /// </para>
    /// </summary>
    public abstract class ModuleServiceRegistryBase
        : ModuleServiceRegistryBaseBase
    {
        /// <summary>
        /// Override to define what to find
        /// and register 
        /// within this logical Module's assemblies.
        /// <para>
        /// Not that it already been scoped to the
        /// logical module's assemblies.
        /// </para>
        /// </summary>
        /// <param name="assemblyScanner">The assembly scanner.</param>
        protected override void InnerScan(IAssemblyScanner assemblyScanner)
        {
            //Do nothing.
        }

    }
}

