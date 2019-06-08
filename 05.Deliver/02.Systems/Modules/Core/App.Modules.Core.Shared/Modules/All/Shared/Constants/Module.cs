using System;

namespace App.Modules.All.Shared.Constants
{
    public static class Module
    {


        /// <summary>
        /// Returns something like "Core" (note, without trailing Dot)
        /// derived from the given Type's Assembly name (not its Namespace).
        /// </summary>
        public static string Id(Type moduleType)
        {
            return moduleType.Assembly.GetModuleIdentifier();
        }

        /// <summary>
        /// Dot ended prefix of Assembly names belonging to this module.
        /// returns something like "App.Modules." + "Core."
        /// </summary>
        public static string GetAssemblyNamePrefix(Type moduleType)
        {
            return Application.AssemblyModulesPrefix + Id(moduleType);
        }
    }
}
