using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.All.Shared.Constants;

namespace App
{
    /// <summary>
    /// Extension methods to <see cref="Type"/>s.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the provided Type is
        /// from an assembly within this app (versus a Type
        /// from a 3rd party library, or .NET Framework).
        /// </summary>
        /// <param name="type">The type.</param>
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

        /// <summary>
        /// Determines whether the given type is same logical module as the referenced type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="referenceType">Type of the reference.</param>
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

