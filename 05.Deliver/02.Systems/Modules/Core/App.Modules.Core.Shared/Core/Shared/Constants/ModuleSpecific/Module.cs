using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Shared.Constants.ModuleSpecific
{
    public static class Module
    {


        /// <summary>
        /// Returns something like "Core" (note, without trailing Dot).
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
