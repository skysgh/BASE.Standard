//using System;
//using System.Linq;
//using App.Modules.Core.Infrastructure.Integration.Azure.Storage;
//using Lamar;
//using Lamar.Scanning;
//using Lamar.Scanning.Conventions;

//namespace App.Modules.Core.Infrastructure.DependencyInjection
//{

//    public class ServiceConfigurationRegistrationConvention : IRegistrationConvention
//    {
//        public void ScanTypes(TypeSet types, ServiceRegistry services)
//        {
//            // Only work on concrete types
//            var typesFound =
//                types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
//                .Where(x =>
//                typeof(IAzureStorageBlobContext).IsAssignableFrom(x)
//                )
//                .ToArray();

//            foreach (Type type in typesFound)
//            {
//                services.For(type).Use(type).Singleton();
//            };
//        }


//            //private void ScanAllModulesAndRegisterNamedInstancesOfStorageAccountContexts(IAssemblyScanner assemblyScanner)
//            //{
//            //    var types = AppDomain.CurrentDomain
//            .GetInstantiableTypesImplementing<IAzureStorageBlobContext>();
//            //    foreach (Type t in types)
//            //    {
//            //        string name = t.GetName(false);

//            //        if (name == null)
//            //        {
//            //            throw new Exception("Coding error: StorageAccountContexts need to be Named, using a KeyAttribute.");
//            //        }

//            //        //Register it under IAzureStorageBlobContext context, but named:

//            //        new CreatePluginFamilyExpression<IAzureStorageBlobContext>(this,
//            //                new HttpContextLifecycle()).HybridHttpOrThreadLocalScoped()
//            //            .Use(y => (IAzureStorageBlobContext)AppDependencyLocator.Current.GetInstance(t)).Named(name);
//            //    }
//            //}


//        }
//}
