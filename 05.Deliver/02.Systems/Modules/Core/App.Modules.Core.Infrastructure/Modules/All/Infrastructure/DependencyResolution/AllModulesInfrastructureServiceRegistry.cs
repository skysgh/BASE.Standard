﻿using App.Modules.All.Infrastructure.Data.Db.CommitInterceptions;
using App.Modules.All.Infrastructure.ServiceAgents;
using Lamar.Scanning.Conventions;

namespace App.Modules.All.Infrastructure.DependencyResolution
{
    /// <summary>
    /// <para>
    /// Invoked by magic. 
    /// ie, found because App.Host/DependencyInjection/ServiceRegistry 
    /// had an 'LookForRegistries' statement.
    /// </para>
    /// </summary>
    public class AllModulesInfrastructureServiceRegistry : Lamar.ServiceRegistry
    {
        public AllModulesInfrastructureServiceRegistry()
        {
            Scan();


        }

        private void Scan()
        {
            Scan(
                assemblyScanner =>
                {
                    //Where we want to be:
                    // Want this scanner to search in all Assemblies related to this system.
                    // Which we can see from the dll's name (as long as everybody
                    // sticks to the convention of "App...." 
                    assemblyScanner.AssembliesFromApplicationBaseDirectory(
                        x => x.IsSameApp());


                    //ScanAllModulesForAllModulesOIDCFullyQualifiesScopes(assemblyScanner);

                    ScanAllModulesForAllModulesPrecommitStrategies(assemblyScanner);

                    ScanAllModulesForRequestScopedServiceClients(assemblyScanner);

                    //ScanAllModulesAndRegisterNamedInstancesOfStorageAccountContexts(assemblyScanner);

                    //ScanAllModulesAndRegisterNamedInstancesOfNamedCacheInitializers(assemblyScanner);
                    //InfrastructureCoreMappings(assemblyScanner);

                    //// As well as the default scanner, find any custom scanners 
                    //// (eg: our custom MVC5 Controller scanner) and use them as well :
                    //AppDomain.CurrentDomain
                    //    .InvokeImplementing<ICustomRegistrationConvention>(assemblyScanner.With);
                }
            );
        }


        private void ScanAllModulesForRequestScopedServiceClients(IAssemblyScanner assemblyScanner)
        {
            // Service agents are scoped to Request.
            assemblyScanner.AddAllTypesOf<IContextScopedServiceAgent>();
        }




        //private void ScanAllModulesForAllModulesOIDCFullyQualifiesScopes(IAssemblyScanner assemblyScanner)
        //{
        //    assemblyScanner.AddAllTypesOf<IHasOidcScopeInitializer>();
        //}


        private void ScanAllModulesForAllModulesPrecommitStrategies(IAssemblyScanner assemblyScanner)
        {
            // Add all Pre-Commit Processors (these kick in just as you
            // Commit a DbContext, and ensure specific fields are 
            // automatically filled in)
            assemblyScanner.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();
        }


        //private void ScanAllModulesAndRegisterNamedInstancesOfNamedCacheInitializers(IAssemblyScanner assemblyScanner)
        //{

        //    var types = AppDomain.CurrentDomain.GetInstantiableTypesImplementing<IAppCoreCacheItem>();

        //    foreach (Type t in types)
        //    {
        //        //Get the item's KeyAttribute:
        //        string name = t.GetName(false);

        //        if (name == null)
        //        {
        //            throw new DevelopmentException($"Implementations of IAppCoreCacheItem (ie {t.Name}) need to be Named, using a KeyAttribute.");
        //        }

        //        new CreatePluginFamilyExpression<IAppCoreCacheItem>(this,
        //                            new StructureMap.Pipeline.SingletonLifecycle())
        //                            .Use(y => (IAppCoreCacheItem)AppDependencyLocator.Current.GetInstance(t)).Named(name);
        //    }
        //}



    }
}
