using System;
using System.Collections.Generic;
using App.Modules.Core.AppFacade.Initialization.Mvc;
using App.Modules.Core.AppFacade.Initialization.OData;
using App.Modules.Core.Infrastructure.Initialization.ObjectMaps;
using Lamar;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.Core.AppFacade
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
                assemblyScanner.AssembliesFromApplicationBaseDirectory(
                    x => x.GetName().Name.StartsWith(
                        App.Modules.Core.Shared.Constants.Application.AssemblyPrefix
                    ));


                ScanAllModulesForMvcRouting(assemblyScanner);
                ScanAllModulesForODataModelDefinitions(assemblyScanner);
            });
        }


        private void ScanAllModulesForMvcRouting(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IModuleRoutes>().NameBy(x => x.FullName);
        }

        private void ScanAllModulesForODataModelDefinitions(IAssemblyScanner assemblyScanner)
        {
            assemblyScanner.AddAllTypesOf<IAppCoreOdataModelBuilderConfiguration>();
        }
    }
}
