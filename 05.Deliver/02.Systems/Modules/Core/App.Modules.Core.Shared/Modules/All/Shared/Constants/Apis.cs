using System;

namespace App.Modules.All.Shared.Constants
{
    /// <summary>
    /// Constants regarding API development.
    /// </summary>
    public static class Apis
    {
        //Old way:            Id = typeof(Module).Assembly.GetModuleIdentifier();
        /// <summary>
        /// The path prefix of all APIs ("api/")
        /// </summary>
        public const string BasePath = "api/";

        /// <summary>
        /// The path prefix of all OData based APIs ("api/odata/")
        /// </summary>
        public const string BaseODataPath = BasePath + "odata/";


        /// <summary>
        /// The Identifier of the given Logical Module (eg: "Core", "etc.").
        /// <para>
        /// The closest one can get to a Constant...
        /// </para>
        /// </summary>
        /// <param name="moduleType">Type of the module.</param>
        /// <returns></returns>
        public static string ModuleId(Type moduleType)
        {
            return Module.Id(moduleType);
        }
    }
}

