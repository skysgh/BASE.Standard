using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Shared.Constants.ModuleSpecific
{
    public class Apis
    {
        static Apis()
        {
            Id = typeof(Module).Assembly.GetModuleIdentifier();
        }

        public static string Id { get; private set; }

        //public const string ApiPathRoot = All.Apis.BasePath + Id + "\\";


    }
}
