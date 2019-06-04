// Extensions are always put in root namespace
// for maximum usability from elsewhere:

using App.Modules.Core.Models;

namespace App.Modules.Core.Infrastructure.ExtensionMethods
{
    public static class IHasSerializedTypeValueExtensions
    {
        public static object Deserialize(this IHasSerializedTypeValue source)
        {
            // TODO
            return null;
        }
    }
}