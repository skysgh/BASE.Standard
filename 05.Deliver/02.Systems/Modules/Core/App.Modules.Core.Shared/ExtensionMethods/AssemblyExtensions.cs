using System.Reflection;
using App.Modules.All.Shared.Constants;

namespace App
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Extension method that extracts the name of the
        /// App Module (Core, Module01, etc.)
        /// from the given Assembly (not the namespace).
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string GetModuleIdentifier(this Assembly assembly)
        {
            var result = assembly.GetName().Name;
            //Whatever the name of the assembly, eg: "App.Modules.Core.Something"
            // first work back to "Core.Standard" 
            result = result.Substring(Application.AssemblyModulesPrefix.Length);
            // Then take just "Core".
            result = result.Substring(0, result.IndexOf('.'));

            
            return result;
        }
    }
}
