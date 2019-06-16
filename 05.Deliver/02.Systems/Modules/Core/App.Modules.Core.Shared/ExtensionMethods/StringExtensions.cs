using System;

namespace App
{
    /// <summary>
    /// Extension methods on strnigs
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether this string contains the given string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="value">The value.</param>
        /// <param name="stringComparison">The string comparison.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            if (text == null || value == null)
            {
                return false;
            }

            return text.IndexOf(value, stringComparison) >= 0;
        }
    }
}
