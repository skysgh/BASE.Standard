using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace App.Diagrams.PlantUml.Uml
{
    public static class StringExtensions
    {

        public static string FormatStringInvariantCulture(this string text, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, text, args);
        }

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        /// <summary>
        /// Repeats the given text a specific number of times.
        /// <para>
        /// eg:, given '\t', can be used to get back '\t\t\t'
        /// </para>
        /// </summary>
        /// <param name="textToRepeat">The text to repeat.</param>
        /// <param name="numberOfTimesToRepeat">The number of times to repeat.</param>
        /// <returns></returns>
        public static string Repeat(this string textToRepeat, int numberOfTimesToRepeat)
        {
            return string.Concat(Enumerable.Repeat(textToRepeat, numberOfTimesToRepeat));
        }

    }
}
