// Extensions are always put in root namespace
// for maximum usability from elsewhere:

using App.Modules.All.Shared.Models;

namespace App
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