using System.Reflection;
using App.Modules.All.Shared.Attributes;

namespace App
{
    public static class PropertyInfoExtensions
    {

        public static string GetAlias(this PropertyInfo propertyInfo)
        {

            // Use aliases first, as they can be richer, if there are any:
            var aliasAttribute = propertyInfo.GetCustomAttribute<AliasAttribute>();

            if (aliasAttribute != null)
            {
                return aliasAttribute.DisplayName;
            }
            return null;
        }
    }
}
