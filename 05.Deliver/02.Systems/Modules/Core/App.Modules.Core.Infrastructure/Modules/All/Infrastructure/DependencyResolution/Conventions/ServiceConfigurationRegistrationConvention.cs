// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Infrastructure.Exceptions;
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
        private readonly Type contractType = typeof(IConfigurationObject);

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

                var tag = implementationType
                    .GetAliasKeyOrNameFromType(
                        "ServiceConfiguration",
                        "ConfigurationSettings",
                        "Configuration");

                services.For(contractType).Use(implementationType).Singleton().Named(tag).Scoped();
                services.For(implementationType).Use(implementationType).Singleton().Scoped();
            }

            ;
        }
    }
}