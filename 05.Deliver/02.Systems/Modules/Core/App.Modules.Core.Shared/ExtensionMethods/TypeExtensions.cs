using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.All.Shared.Constants;

namespace App
{
    public static class TypeExtensions
    {
        public static bool IsSameApp(this Type type)
        {
            // eg: "App.Modules.Core.Standard"
            string name = type.Assembly.GetName().Name;

            // return that it starts with "App.Modules."
            return name.StartsWith(
                Application.AssemblyModulesPrefix);
        }

        /// <summary>
        /// Returns something like "Core" (note, without trailing Dot)
        /// derived from the given Type's Assembly name
        /// (not its Namespace).
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string GetModuleIdentifier(this Type type)
        {
            return type.Assembly.GetModuleIdentifier();
        }

        public static bool IsSameLogicalModuleAs(this Type type, Type referenceType)
        {
            return 
                string.Equals(
                    type.GetModuleIdentifier(), 
                    referenceType.GetModuleIdentifier()
                    );

            //eg: "App.Modules.Core.Standard
            //string name = type.Assembly.GetName().Name;

            //return name.StartsWith(
            //    Module.
            //    GetAssemblyNamePrefix(referenceType));
        }


    }
}

