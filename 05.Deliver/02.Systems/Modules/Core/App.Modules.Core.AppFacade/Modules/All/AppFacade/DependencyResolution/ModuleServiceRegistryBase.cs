using App.Modules.All.Infrastructure.DependencyResolution;
using App.Modules.Core.AppFacade.Initialization.Startup;
using Lamar.Scanning.Conventions;

namespace App.Modules.All.AppFacade.DependencyResolution
{
    /// <summary>
    /// The base class for each Module's (Core, Module1, Module2, etc.) ServiceRegistry.
    /// <para>
    /// To avoid undesired side effects, It's important that each Module
    /// inherits from this Module as it is set up to only search for dependencies
    /// within this Module's group of assemblies (it's filtering on the Assembly name)
    /// </para>
    /// </summary>
    public abstract class ModuleServiceRegistryBase : ModuleServiceRegistryBaseBase
    {


        /// <summary>
        /// Scans this Module's assemblies for
        /// as per specifications.
        /// </summary>
        protected override void InnerScan(IAssemblyScanner assemblyScanner)
        {

            ScanThisLogicalModuleForMvcRouting(assemblyScanner);
        }


        private void ScanThisLogicalModuleForMvcRouting(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IModuleRoutes>().NameBy(x => x.FullName);
        }


    }
}
