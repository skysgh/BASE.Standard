// Extensions are always put in root namespace
// for maximum usability from elsewhere:

using App.Modules.Core.Factories;

namespace App
{
    using System;

    public static class GuidExtensions
    {
        public static Guid Generate(this Guid guid)
        {
            return GuidFactory.NewGuid();
        }
    }
}