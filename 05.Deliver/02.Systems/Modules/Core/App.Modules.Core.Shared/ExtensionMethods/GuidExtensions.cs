// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Factories;

namespace App
{
    /// <summary>
    ///     Extensions to <see cref="Guid" />
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        ///     Generates a new unique sequential identifier.
        /// </summary>
        /// <param name="guid">The unique identifier.</param>
        /// <returns></returns>
        public static Guid Generate(this Guid guid)
        {
            return GuidFactory.NewGuid();
        }
    }
}