using App.Modules.All.Infrastructure.Data.Db.Schema;
using App.Modules.All.Infrastructure.Data.Db.Seeding.ImmutableData;
using App.Modules.All.Infrastructure.Data.Db.Seeding.MutableData;
using App.Modules.All.Infrastructure.DependencyResolution.Conventions;
using Lamar.Scanning.Conventions;

namespace App.Modules.All.Infrastructure.DependencyResolution
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
        /// <para>
        /// Invoked by Constructor.
        /// </para>
        /// Override to provide Module/Assembly specific scanning rules.
        /// </summary>
        /// <param name="assemblyScanner">The assembly scanner.</param>
        protected override void InnerScan(IAssemblyScanner assemblyScanner)
        {
            // Now scan for DbContext Model definitions and then seeders.
            ScanAllModulesForModuleSpecificDbContextTypes(assemblyScanner);
        }


        // Scan across all known assemblies for DbContext related model definitions
        // And seeding definitions, and define the DbContext lifespan:
        private void ScanAllModulesForModuleSpecificDbContextTypes(IAssemblyScanner assemblyScanner)
        {
            // First, define the Model by looking for Module specific model definers:
            assemblyScanner.AddAllTypesOf<IHasModuleSpecificDbContextModelBuilderSchemaInitializer>();

            // Then when the model is defined, look for Module specific DB Seeders:
            // Note that these could have been defined within the Schema Modules
            // But best to keep them separate:
            assemblyScanner.AddAllTypesOf<IHasModuleSpecificDbContextModelBuilderImmutableDataSeedingInitializer>();

            // Then when the model is defined, look for Module specific DB Seeders
            // of Mutable data (eg: Demo stuff) that may or may not be invoked.
            assemblyScanner.AddAllTypesOf<IHasModuleSpecificDbContextMutableDataSeedingInitializer>();

            // Find all DbContexts in this Module (only) and register them *by name* as well as by Type.
            assemblyScanner.Convention<NamedDbContextRegistrationConvention>();

            // Ad a scnaning convention for scanning and registering 
            // ServiceConfiguration concrete types that are not backed by interfaces:
            assemblyScanner.Convention<ServiceConfigurationRegistrationConvention>();
        }
    }
}