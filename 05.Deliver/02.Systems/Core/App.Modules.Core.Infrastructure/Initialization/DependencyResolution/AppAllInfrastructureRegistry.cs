using System;
using System.Collections.Generic;
using App.Modules.Core.Infrastructure.Initialization.ObjectMaps;
using Lamar;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.DependencyInjection;

//using App.Modules.Core.Infrastructure.Cache;
//using App.Modules.Core.Infrastructure.Db.Interception;
//using App.Modules.Core.Infrastructure.Initialization.Authentication;
//using App.Modules.Core.Infrastructure.Initialization.ObjectMaps;
//using App.Modules.Core.Infrastructure.Integration.Azure.Storage;


namespace App.Modules.Core.Infrastructure.Initialization.DependencyResolution
{
    /// <summary>
    /// <para>
    /// Invoked by magic. 
    /// ie, found because App.Host/DependencyInjection/ServiceRegistry 
    /// had an 'LookForRegistries' statement.
    /// </para>
    /// </summary>
    public class AppAllInfrastructureRegistry : Lamar.ServiceRegistry
    {
        public AppAllInfrastructureRegistry()
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
                        x => x.GetName().Name.StartsWith(
                            App.Modules.Core.Shared.Constants.Application.AssemblyPrefix
                        ));

                    ScanAllModulesForAllModulesAutoMapperInitializers(assemblyScanner);

                    //ScanAllModulesForAllModulesOIDCFullyQualifiesScopes(assemblyScanner);

                    //ScanAllModulesForAllModulesPrecommitStrategies(assemblyScanner);

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

        private void ScanAllModulesForAllModulesAutoMapperInitializers(IAssemblyScanner assemblyScanner)
        {
            // Register all Automapper Instances, which ever assembly they are in :
            assemblyScanner.AddAllTypesOf<IHasAutomapperInitializer>();
        }

        //private void InfrastructureCoreMappings(IAssemblyScanner assemblyScanner)
        //{
        //    For<IAzureRedisConnection>().Use<AzureRedisConnection>().Singleton();
        //    For<AzureRedisCacheServiceConfiguration>().Use<AzureRedisCacheServiceConfiguration>().Singleton();
        //    For<ISessionManagmentService>().Use<SessionManagmentService>().Singleton();
        //}




        //private void ScanAllModulesForAllModulesOIDCFullyQualifiesScopes(IAssemblyScanner assemblyScanner)
        //{
        //    assemblyScanner.AddAllTypesOf<IHasOidcScopeInitializer>();
        //}


        //private void ScanAllModulesForAllModulesPrecommitStrategies(IAssemblyScanner assemblyScanner)
        //{
        //    // Add all Pre-Commit Processors (these kick in just as you
        //    // Commit a DbContext, and ensure specific fields are 
        //    // automatically filled in)
        //    assemblyScanner.AddAllTypesOf<IDbCommitPreCommitProcessingStrategy>();
        //}


        ////SKYOUT: private void ScanAllModulesForModuleSpecificODataBuilderTypes(IAssemblyScanner assemblyScanner)
        ////{
        ////    // Note that because we are in App.Modules.Core.Infrastructure, we can't see the
        ////    // Typed version of this interface (as this assembly does not know anything 
        ////    // about OData as it does not have a Ref to OData Assemblies...nor should it, as that
        ////    // woudl drag in way too many other dependencies (ApiControllers, Web, etc.)
        ////    // So we search for and register the *untyped* version of the interface:

        ////    //Scan for OData Model Builders in *all* modules.
        ////    assemblyScanner.AddAllTypesOf<IAppODataModelBuilder>();
        ////    //Scan for OData Model Builder Configuration fragments in *all* modules.
        ////    assemblyScanner.AddAllTypesOf<IAppODataModelBuilderConfiguration>();
        ////}


        //private void ScanAllModulesAndRegisterNamedInstancesOfStorageAccountContexts(IAssemblyScanner assemblyScanner)
        //{
        //    var types = AppDomain.CurrentDomain.GetInstantiableTypesImplementing<IAzureStorageBlobContext>();
        //    foreach (Type t in types)
        //    {
        //        string name = t.GetName(false);

        //        if (name == null)
        //        {
        //            throw new Exception("Coding error: StorageAccountContexts need to be Named, using a KeyAttribute.");
        //        }

        //        //Register it under IAzureStorageBlobContext context, but named:

        //        new CreatePluginFamilyExpression<IAzureStorageBlobContext>(this,
        //                new HttpContextLifecycle()).HybridHttpOrThreadLocalScoped()
        //            .Use(y => (IAzureStorageBlobContext)AppDependencyLocator.Current.GetInstance(t)).Named(name);
        //    }
        //}


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
