using System;

namespace App.Modules.All.Shared.Constants
{
    public static class Apis
    {
        //Old way:            Id = typeof(Module).Assembly.GetModuleIdentifier();
        public const string BasePath = "api/";
        public const string BaseODataPath = BasePath + "odata/";

        public static string ModuleId(Type moduleType)
        {
            return Module.Id(moduleType);
        }
    }
}

