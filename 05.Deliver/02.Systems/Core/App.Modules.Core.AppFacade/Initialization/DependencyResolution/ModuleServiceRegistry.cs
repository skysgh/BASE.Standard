using System;
using System.Collections.Generic;
using App.Modules.Core.Infrastructure.Initialization.ObjectMaps;
using Lamar;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace App.Modules.Core.AppFacade
{
    public class ModuleServiceRegistry : Lamar.ServiceRegistry
    {
        public ModuleServiceRegistry()
        {
            //Scan(assemblyScanner =>
            //{
            //    // Want to search in all Assemblies related to this system.
            //    // Which we can see from the dll's name (as long as everybody
            //    // sticks to the convention of "App...." 
            //    assemblyScanner.AssembliesFromApplicationBaseDirectory(
            //        x => x.GetName().Name.StartsWith(
            //            App.Modules.Core.Shared.Constants.Application.APPPREFIX
            //        ));


            //    ScanAllModulesForAllModulesAutoMapperInitializers(assemblyScanner);
            //});
        }


        //private void ScanAllModulesForAllModulesAutoMapperInitializers(IAssemblyScanner assemblyScanner)
        //{
        //    // Register all Automapper Instances, which ever assembly they are in :
        //    assemblyScanner.AddAllTypesOf<IHasAutomapperInitializer>();
        //}

    }
}
