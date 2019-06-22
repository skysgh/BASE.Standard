// Copyright MachineBrains, Inc. 2019

using System;

namespace App
{
    /// <summary>
    ///     Extensions to integers
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        ///     Converts an integer to a Guid unique identifier
        ///     (obviously not very random).
        ///     <para>
        ///         Useful for initial seeding scenarios.
        ///     </para>
        /// </summary>
        /// <returns></returns>
        public static Guid ToGuid(this int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}