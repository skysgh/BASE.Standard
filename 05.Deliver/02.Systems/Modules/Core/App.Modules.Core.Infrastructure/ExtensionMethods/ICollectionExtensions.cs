using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace App.ExtensionMethods
{
    public static class ICollectionExtensions
    {

        /// <summary>
        /// Adds the items to the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="itemsToAdd">The items to add.</param>
        public static void AddRange<T>(this ICollection<T> collection,
            IEnumerable<T> itemsToAdd)
        {
            if (itemsToAdd == null)
            {
                return;
            }
            foreach (var tmp in itemsToAdd)
            {
                collection.Add(tmp);
            }
        }
    }
}
