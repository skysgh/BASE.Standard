using System;
using System.Collections.Generic;
using System.Text;

namespace App.Diagrams.PlantUml.Uml
{
    public static class ICollectionExtensions
    {

        /// <summary>
        /// Adds the items in the source to the destination collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="destination">The destination.</param>
        /// <param name="source">The source.</param>
        public static void Add<T>(this ICollection<T> destination,
            IEnumerable<T> source)
        {
            if (source == null) { return; }

            foreach (T item in source)
            {
                destination.Add(item);
            }
        }

    }
}
