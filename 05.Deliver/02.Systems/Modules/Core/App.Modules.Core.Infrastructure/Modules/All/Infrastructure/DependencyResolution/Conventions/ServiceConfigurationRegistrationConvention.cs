// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.Infrastructure.Exceptions;
using App.Modules.Core.Infrastructure.Services.Configuration;
using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;

namespace App.Modules.All.Infrastructure.DependencyResolution.Conventions
{
    /// <summary>
    ///     Some services are configured using 'xxxConfiguration' objects,
    ///     that are not backed by Interfaces -- but need to be
    ///     registered as Singletons.
    /// </summary>
    public class ServiceConfigurationRegistrationConvention : IRegistrationConvention
    {
        private readonly Type contractType = typeof(IServiceConfigurationObject);

        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {
            // Only work on concrete types
            Type[] typesFound =
                types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed)
                    .Where(x =>
                        contractType.IsAssignableFrom(x)
                        ||
                        x.Name.EndsWith("ServiceConfiguration"))
                    .ToArray();

            foreach (var implementationType in typesFound)
            {
                if (!contractType.IsAssignableFrom(implementationType))
                {
                    throw new ConfigurationException(
                        $"Found a `{implementationType.Name}` but it doesn't follow the convention of deriving from `{contractType.Name}`.");
                }

                var tag = GetName(implementationType);

                services.For(contractType).Use(implementationType).Singleton().Named(tag).Scoped();
                services.For(implementationType).Use(implementationType).Singleton().Scoped();
            }

            ;
        }


        private string GetName(Type type)
        {
            // Register against all the interfaces implemented
            // by this concrete class
            var name = type.GetName();

            if (name != null)
            {
                return null;
            }

            name = type.Name;
            var tmp = "ServiceConfiguration";
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