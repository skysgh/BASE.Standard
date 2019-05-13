using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace App.Diagrams.PlantUml.Uml
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Gets Distinct elements (ie no duplicates) for the collection, based on the value of evaluation of the given property expression on each item.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Expression<Func<TSource, TKey>> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();

            Func<TSource, TKey> compiled = keySelector.Compile();

            foreach (TSource element in source)
            {

                TKey x = compiled.Invoke(element);

                if (!seenKeys.Contains(x))
                {
                    seenKeys.Add(x);
                    yield return element;
                }
            }
        }



        /// <summary>
        /// Gets the duplicates.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> GetDuplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var grouped = source.GroupBy(selector);
            var moreThen1 = grouped.Where(i => i.IsMultiple());

            return moreThen1.SelectMany(i => i);
        }

        public static bool IsMultiple<T>(this IEnumerable<T> source)
        {
            var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() && enumerator.MoveNext();
        }

        /// <summary>
        /// Performs a topological sort over the source list.
        /// <para>
        /// Usage:
        /// <![CDATA[
        /// void Main()
        /// {
        /// 	List<Foo> items = new List<Foo>();
        /// 	items.Add(new Foo{Id="A"});
        /// 	items.Add(new Foo{Id="B",ConditionalOn="D"});
        /// 	items.Add(new Foo{Id="C",ConditionalOn="B"});
        /// 	items.Add(new Foo{Id="D"});
        /// 	items.Add(new Foo{Id="E"});
        /// 	
        /// 	items.TSort(x=> items.Where(y=>y.Id== x.ConditionalOn)).Dump();
        /// }
        ///  public class Foo {
        ///      public string Id { get; set; }
        ///      public string ConditionalOn { get; set; }
        ///  }
        /// ]]>
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="dependencies">The dependencies.</param>
        /// <param name="throwOnCycle">if set to <c>true</c> [throw on cycle].</param>
        /// <returns></returns>
        public static IEnumerable<T> TopologicalSort<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> dependencies, bool throwOnCycle = false)
        {
            var sorted = new List<T>();
            var visited = new HashSet<T>();

            foreach (var item in source)
            {
                Visit(item, visited, sorted, dependencies, throwOnCycle);
            }
            return sorted;
        }

        private static void Visit<T>(T item, HashSet<T> visited, List<T> sorted, Func<T, IEnumerable<T>> dependencies, bool throwOnCycle)
        {
            if (visited.Contains(item))
            {
                if (throwOnCycle)
                {
                    throw new Exception("Cyclic dependency found");
                }
            }
            else
            {
                visited.Add(item);

                foreach (var dep in dependencies(item))
                {
                    Visit(dep, visited, sorted, dependencies, throwOnCycle);
                }
                sorted.Add(item);
            }
        }




    }
}
