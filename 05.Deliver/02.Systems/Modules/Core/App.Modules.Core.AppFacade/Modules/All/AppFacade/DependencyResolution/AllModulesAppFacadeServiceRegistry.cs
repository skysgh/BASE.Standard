using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;
using App.Modules.All.AppFacade.Initialization.Views;
using App.Modules.Core.AppFacade.Initialization.Startup;
using Lamar.Scanning.Conventions;

namespace App.Modules.All.AppFacade.DependencyResolution
{
    public class AllModulesAppFacadeServiceRegistry : Lamar.ServiceRegistry
    {
        public AllModulesAppFacadeServiceRegistry()
        {
            Scan(assemblyScanner =>
            {
                // Want to search in all Assemblies related to this system.
                // Which we can see from the dll's name (as long as everybody
                // sticks to the convention of "App...." 
                assemblyScanner
                    .AssembliesFromApplicationBaseDirectory(
                        x => x.IsSameApp()
                    );

                ScanAllModulesForStartupExtensions(assemblyScanner);
                ScanAllModulesForMvcRouting(assemblyScanner);
                ScanAllModulesForViewAssemblyRegistration(assemblyScanner);
                ScanAllModulesForODataModelDefinitions(assemblyScanner);
            });
        }

        private void ScanAllModulesForStartupExtensions(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IStartupConfigure>().NameBy(x => x.FullName);
        }

        private void ScanAllModulesForMvcRouting(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IModuleRoutes>().NameBy(x => x.FullName);
        }
        private void ScanAllModulesForViewAssemblyRegistration(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IAllModulesViewArtifactRegistration>().NameBy(x => x.FullName);
        }

        private void ScanAllModulesForODataModelDefinitions(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IAllModulesOdataModelBuilderConfiguration>();
        }
    }
}
