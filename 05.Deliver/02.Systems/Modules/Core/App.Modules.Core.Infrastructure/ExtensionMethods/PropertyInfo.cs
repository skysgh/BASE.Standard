using System.Reflection;

namespace App.Modules.Core.Infrastructure.ExtensionMethods
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
