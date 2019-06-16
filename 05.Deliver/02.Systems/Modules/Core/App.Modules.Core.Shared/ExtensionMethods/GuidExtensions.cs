// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using App.Modules.All.Shared.Factories;


    /// <summary>
    /// Extensions to <see cref="Guid"/>
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Generates a new unique sequential identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public static Guid Generate(this Guid guid)
        {
            return GuidFactory.NewGuid();
        }
    }
}