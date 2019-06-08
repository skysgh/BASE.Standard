// Extensions are always put in root namespace
// for maximum usability from elsewhere:

using System;
using System.Linq;
using System.Reflection;
using App.Modules.All.Shared.Attributes;

namespace App
{
    public static class TypeExtensions
    {

        public static bool IsSameOrSubclassOf(this Type potentialDescendant, Type potentialBase)
        {
            return potentialDescendant.IsSubclassOf(potentialBase)
                   || potentialDescendant == potentialBase;
        }

        public static object GetDefaultValue(this Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }


        public static string GetName(this Type type, bool inherit = false)
        {
            // Use aliases first, as they can be richer, if there are any:
            var aliasAttribute = CustomAttributeExtensions.GetCustomAttribute<KeyAttribute>(type, inherit);

            return aliasAttribute?.Key;
        }

        public static T GetCustomAttribute<T>(this Type type, bool inherit=true) where T:Attribute
        {
            T result = (T)type.GetCustomAttributes(typeof(T), inherit).FirstOrDefault();
            return result;
        }
    }
}