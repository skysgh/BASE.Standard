using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class NamedDbContextConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, ServiceRegistry services)
        {
            // Only work on concrete types
            var ttt = types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed).ToArray();
            foreach (Type type in ttt.Where(x => (typeof(DbContext).IsAssignableFrom(x))
                //&& (x != (typeof(DbContext)))
                ))
            {
                string tag = GetName(type);
                services.For(typeof(DbContext)).Use(type).Named(tag).Scoped();
                services.For(type).Use(type).Scoped();
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
                return name.Substring(0, type.Name.IndexOf(tmp));
            }

            tmp = "DbContext";
            if (name.Contains(tmp))
            {
                return name.Substring(0, type.Name.IndexOf(tmp));
            }
            return name;
        }
    }
}