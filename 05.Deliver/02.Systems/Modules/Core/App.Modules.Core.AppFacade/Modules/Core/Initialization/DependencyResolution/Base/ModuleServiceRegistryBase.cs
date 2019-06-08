using App.Modules.All.Shared.Constants;
using App.Modules.Core.Initialization.Startup;
using Lamar;
using Lamar.Scanning.Conventions;

namespace App.Modules.Core.Initialization.DependencyResolution.Base
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
        protected string ModuleName => Module.Id(this.GetType());

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

                ScanThisLogicalModuleForMvcRouting(assemblyScanner);

            });
        }


        private void ScanThisLogicalModuleForMvcRouting(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IModuleRoutes>().NameBy(x => x.FullName);
        }


    }
}
