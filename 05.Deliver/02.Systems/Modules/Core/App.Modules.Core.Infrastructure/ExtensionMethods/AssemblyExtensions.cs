// Extensions are always put in root namespace
// for maximum usability from elsewhere:

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.Modules.All.Shared.Constants;
using Module = App.Modules.All.Shared.Constants.Module;

namespace App
{
    public static class AssemblyExtensions
    {
        public static bool IsSameApp(this Assembly assembly)
        {
            string name = assembly.GetName().Name;
            return name.StartsWith(
                Application.AssemblyPrefix);
        }
        public static bool IsSameModuleAs(this Assembly assembly, Type referenceType)
        {
            string name = assembly.GetName().Name;
            return name.StartsWith(
                Module.
                GetAssemblyNamePrefix(referenceType));
        }


        [System.Diagnostics.DebuggerHidden]
        public static IEnumerable<Type> GetInstantiableTypesImplementing(this Assembly assembly, Type type)
        {
            // Return only types that are subsets of the given type (or are same)
            // that are instantiable, and not generic.

            //An Alternate way of investigating whether it is an interface or not
            //is typeof(HasDo).GetInterfaces().Any(x=>x == typeof(IHasDo)).Dump("Implements Interface");
            try
            {
                return assembly.GetTypes().Where(x =>
                    type.IsAssignableFrom(x)
                    &&
                    !x.IsAbstract
                    &&
                    !x.IsInterface
                    &&
                    !x.IsGenericTypeDefinition
                );
            }
            catch (ReflectionTypeLoadException)
            {
                //No biggie
                System.Diagnostics.Trace.TraceInformation($"Running 'GetInstantiableTypesImplementing', could not find {type.Name}");
            }
            return null;
        }
    }
}