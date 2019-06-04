using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Modules.Core.Infrastructure.ExtensionMethods;
using Lamar;
using Lamar.Scanning;
using Lamar.Scanning.Conventions;
using Microsoft.EntityFrameworkCore;

namespace App.Modules.Core.Infrastructure.DependencyInjection
{
    /// <summary>
    /// A Custom Lamar initialization convention used
    /// to register Databases under their name.
    /// </summary>
    public class NamedDbContextRegistrationConvention : IRegistrationConvention
    {
        Type contractType = typeof(DbContext);

        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {

            // Only work on concrete types
            var implementationTypes = types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed).ToArray();
            foreach (Type implementationType in implementationTypes.Where(x => (contractType.IsAssignableFrom(x))
                //&& (x != (typeof(DbContext)))
                ))
            {
                string tag = GetName(implementationType);

                services.For(contractType).Use(implementationType).Named(tag).Scoped();
                services.For(implementationType).Use(implementationType).Scoped();
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
            string tmp = "ModuleDbContext";
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