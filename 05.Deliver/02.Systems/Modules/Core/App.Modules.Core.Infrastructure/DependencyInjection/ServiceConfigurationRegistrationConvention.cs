using System;
using System.Linq;
using App.Modules.Core.Infrastructure.Exceptions;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using App.Modules.Core.Infrastructure.Services.Configuration;
using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;

namespace App.Modules.Core.Infrastructure.DependencyInjection
{
    /// <summary>
    /// Some services are configured using 'xxxConfiguration' objects,
    /// that are not backed by Interfaces -- but need to be 
    /// registered as Singletons.
    /// 
    /// </summary>
    public class ServiceConfigurationRegistrationConvention : IRegistrationConvention
    {
        Type contractType = typeof(IServiceConfigurationObject);

        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {

            // Only work on concrete types
            var typesFound =
                types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
                .Where(x => 
                (contractType.IsAssignableFrom(x)
                ||
                x.Name.EndsWith("ServiceConfiguration")
                ))
                .ToArray();

            foreach (Type implementationType in typesFound)
            {
                if (!(contractType.IsAssignableFrom(implementationType)))
                {
                    throw new ConfigurationException(
                        $"Found a `{implementationType.Name}` but it doesn't follow the convention of deriving from `{contractType.Name}`.");
                }

                var tag = GetName(implementationType);

                services.For(contractType).Use(implementationType).Singleton().Named(tag).Scoped();
                services.For(implementationType).Use(implementationType).Singleton().Scoped();
            };
        }



        private string GetName(Type type)
        {
            // Register against all the interfaces implemented
            // by this concrete class
            string name = type.GetName(false);

            if (name != null)
            {
                return null;
            }
            name = type.Name;
            string tmp = "ServiceConfiguration";
            if (name.Contains(tmp))
            {
                return name.Substring(0, name.IndexOf(tmp));
            }

            tmp = "Configuration";
            if (name.Contains(tmp))
            {
                return name.Substring(0, name.IndexOf(tmp));
            }
            return name;
        }

    }
}