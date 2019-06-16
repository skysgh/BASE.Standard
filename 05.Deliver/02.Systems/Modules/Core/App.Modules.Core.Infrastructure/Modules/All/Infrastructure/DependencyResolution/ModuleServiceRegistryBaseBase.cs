﻿using Lamar;
using Lamar.Scanning.Conventions;

namespace App.Modules.All.Infrastructure.DependencyResolution
{
    public abstract class ModuleServiceRegistryBaseBase : ServiceRegistry
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleServiceRegistryBaseBase"/> class.
        /// </summary>
        protected ModuleServiceRegistryBaseBase()
        {
            Scan(assemblyScanner =>
            {
                ScopeToModuleAssemblies(assemblyScanner);
                ConfigureForDefaultConventions(assemblyScanner);
                InnerScan(assemblyScanner);
            });
        }
        /// <summary>
        /// Scopes the scanner to this module's assemblies.
        /// </summary>
        /// <param name="assemblyScanner">The assembly scanner.</param>
        protected virtual void ScopeToModuleAssemblies(IAssemblyScanner assemblyScanner)
        {
            //Where we want to be:
            // Want this scanner to search in all Assemblies related to this system.
            // And related to *this module* only. (every module registers its own
            // stuff).
            assemblyScanner.AssembliesFromApplicationBaseDirectory(
                x => x.IsSameModuleAs(this.GetType()));
        }

        /// <summary>
        /// Configures the scanner to relate ISomething to Something.
        /// </summary>
        /// <param name="assemblyScanner">The assembly scanner.</param>
        protected virtual void ConfigureForDefaultConventions(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.WithDefaultConventions();
        }


        /// <summary>
        /// Override to prodide Module/Assembly specific scanning rules.
        /// </summary>
        /// <param name="assemblyScanner">The assembly scanner.</param>
        protected abstract void InnerScan(IAssemblyScanner assemblyScanner);

    }
}