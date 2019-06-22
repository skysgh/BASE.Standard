// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.All.Infrastructure.DependencyResolution.Conventions
{
    /// <summary>
    ///     A Custom Lamar initialization convention used
    ///     to register Databases under their name.
    /// </summary>
    public class NamedDbContextRegistrationConvention : IRegistrationConvention
    {
        private readonly Type contractType = typeof(DbContext);

        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {
            // Only work on concrete types
            Type[] implementationTypes =
                types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed).ToArray();
            foreach (var implementationType in implementationTypes.Where(x => contractType.IsAssignableFrom(x)
                //&& (x != (typeof(DbContext)))
            ))
            {
                var tag = GetName(implementationType);

                services.For(contractType).Use(implementationType).Named(tag).Scoped();
                services.For(implementationType).Use(implementationType).Scoped();
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
            var tmp = "ModuleDbContext";
            if (name.Contains(tmp))
            {
                return name.Substring(0, name.IndexOf(tmp));
            }

            tmp = "DbContext";
            if (name.Contains(tmp))
            {
                return name.Substring(0, name.IndexOf(tmp));
            }

            return name;
        }
    }
}