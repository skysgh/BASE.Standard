using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace App
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Extension method that extracts the name of the App Module (Core, Module01, etc.)
        /// from the given Assembly.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetModuleIdentifier(this Assembly assembly)
        {
            var result = assembly.GetName().Name;
            result = result.Substring(App.Modules.Core.Shared.Constants.Application.AssemblyModulesPrefix.Length);
            result = result.Substring(0, result.IndexOf('.'));

            return result;
        }
    }
}
