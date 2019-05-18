using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Infrastructure.DependencyInjection;
using App.Modules.Core.Infrastructure.Initialization.Db;
using Lamar;
using Lamar.Scanning.Conventions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.Initialization.DependencyResolution
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
                    x => x.GetName().Name.StartsWith(
                        App.Modules.Core.Shared.Constants.Module.AssemblyNamePrefix
                    ));

                // Now scan for DbContext Model definitions and then seeders.
                ScanAllModulesForModuleSpecificDbContextTypes(assemblyScanner);
            });
        }


        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanAllModulesForModuleSpecificDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // First, define the Model by looking for Module specific model definers:
            assemblyScanner.AddAllTypesOf<IHasModuleSpecificDbContextModelBuilderInitializer>();
            // Then when the model is defined, look for Module specific DB Seeders:
            assemblyScanner.AddAllTypesOf<IHasModuleSpecificDbContextSeedInitializer>();
            // Find all DbContexts in this Module (only) and register them *by name* as well as by Type.
            //assemblyScanner.AddAllTypesOf<DbContext>();
            assemblyScanner.Convention<NamedDbContextConvention>();
        }
    }
}