using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Shared.Constants
{
    public static class Module
    {

        static Module()
        {
            Id = typeof(Module).Assembly.GetModuleIdentifier();
        }

        /// <summary>
        /// Returns something like "Core" (note, without trailing Dot).
        /// </summary>
        public static string Id { get; private set; }

        /// <summary>
        /// Dot ended prefix of Assembly names belonging to this module.
        /// returns something like "App.Modules.Core."
        /// </summary>
        public static string AssemblyNamePrefix = Application.AssemblyModulesPrefix + Id;
    }
}
