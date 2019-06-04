//using System;
//using System.Linq;
//using App.Modules.Core.Infrastructure.ServiceAgents;
//using App.Modules.Core.Infrastructure.Services.Configuration;
//using Lamar;
//using Lamar.Scanning;
//using Lamar.Scanning.Conventions;

//namespace App.Modules.Core.Infrastructure.DependencyInjection
//{
//    /// <summary>
//    /// Some services are configured using 'xxxConfiguration' objects,
//    /// that are not backed by Interfaces -- but need to be 
//    /// registered as Singletons.
//    /// 
//    /// </summary>
//    public class ServiceConfigurationRegistrationConvention : IRegistrationConvention
//    {
//        public void ScanTypes(TypeSet types, ServiceRegistry services)
//        {
//            var contractType = typeof(IContextScopedServiceAgent);
//
//            // Only work on concrete types
//            var typesFound =
//                types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
//                .Where(x => 
//                (typeof(IContextScopedServiceAgent).IsAssignableFrom(x)
//                ))
//                .ToArray();

//            foreach (Type type in typesFound)
//            {
//                services.For(type).Use(type).Singleton();
//            };
//        }

//    }
//}