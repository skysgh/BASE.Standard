// Copyright MachineBrains, Inc.

using Lamar;
using Lamar.Scanning.Conventions;

namespace App.Modules.Core.Initialization.DependencyResolution
{
    /// <summary>
    /// The base class for each Module's (Core, Module1, Module2, etc.) ServiceRegistry.
    /// <para>
    /// To avoid undesired side effects, It's important that each Module
    /// inherits from this Module as it is set up to only search for dependencies
    /// within this Module's group of assemblies (it's filtering on the Assembly name)
    /// </para>
    /// </summary>
    public abstract class ModuleServiceRegistryBase : ServiceRegistry
    {

        protected ModuleServiceRegistryBase()
        {
            Scan();
        }

        public virtual void Scan()
        {
            Scan(assemblyScanner =>
            {

                //Where we want to be:
                // Want this scanner to search in all Assemblies related to this system.
                // And related to *this module* only. (every module registers its own
                // stuff).
                assemblyScanner.AssembliesFromApplicationBaseDirectory(
                    x => x.IsSameModuleAs(this.GetType()));

                Example(assemblyScanner);
            });
        }

        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void Example(IAssemblyScanner assemblyScanner)
        {
            // First, define the Model by looking for Module specific model definers:
            assemblyScanner.AddAllTypesOf<IHasServiceDependencyExample>();
        }

        public interface IHasServiceDependencyExample
        {
        }
    }
}

