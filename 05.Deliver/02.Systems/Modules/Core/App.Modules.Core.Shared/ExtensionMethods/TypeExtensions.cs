using System;
using System.Collections.Generic;
using System.Text;

namespace App
{
    public static class TypeExtensions
    {
        public static bool IsSameApp(this Type type)
        {
            string name = type.Assembly.GetName().Name;
            return name.StartsWith(
                App.Modules.Core.Shared.Constants.Application.AssemblyPrefix);
        }

        public static bool IsSameLogicalModuleAs(this Type type, Type referenceType)
        {
            string name = type.Assembly.GetName().Name;
            return name.StartsWith(
                App.Modules.Core.Shared.Constants.ModuleSpecific.Module.
                GetAssemblyNamePrefix(referenceType));
        }


    }
}

