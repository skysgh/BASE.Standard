// Extensions are always put in root namespace
// for maximum usability from elsewhere:

using System;
using System.Collections.Generic;
using System.Linq;
using App.Modules.All.Infrastructure.Attributes;

namespace App
{
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            if (list == null || action == null)
            {
                return;
            }
            foreach (var obj in list)
            {
                action(obj);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T, int> action)
        {
            if (list == null || action == null)
            {
                return;
            }
            var num = 0;
            foreach (var obj in list)
            {
                action(obj, num);
                ++num;
            }
        }

        public static Type[] SortByOrderByAttribute(this IEnumerable<Type> srcTypes)
        {
            var resultList = new List<Type>();

            foreach (var srcItem in srcTypes)
            {
                OrderByAttribute attribute = 
                    srcItem.GetCustomAttributes(typeof(OrderByAttribute), false)
                    .FirstOrDefault() as OrderByAttribute;

                bool found = false;
                if ((attribute != null) && (!string.IsNullOrWhiteSpace(attribute.After)))
                {
                    for (var i = 0; i < resultList.Count; i++)
                    {
                        Type x = resultList[i];
                        OrderByAttribute a = x.GetCustomAttributes(typeof(OrderByAttribute), false).FirstOrDefault() as OrderByAttribute;
                        var key = a?.Key;
                        if (string.IsNullOrEmpty(key)) { key = x.Name; }
                        if (string.Compare(key, attribute.After, true) == 0)
                        {
                            resultList.Insert(i, srcItem);
                            found = true;
                            break;
                        }
                    }
                }
                // Was not found, so add at end:
                if (found)
                {
                    continue;
                }
                resultList.Add(srcItem);
            }
            var results = resultList.ToArray();

            return results;

        }


        public static T[] SortByOrderByAttribute<T>(this IEnumerable<T> sourceItems)
        {
            var resultList = new List<T>();
            foreach (var srcItem in sourceItems)
            {
                Type sourceItemType = (srcItem).GetType();
                OrderByAttribute attribute = sourceItemType.GetCustomAttributes(typeof(OrderByAttribute), false).FirstOrDefault() as OrderByAttribute;

                bool found = false;
                if ((attribute != null) && (!string.IsNullOrWhiteSpace(attribute.After)))
                {
                    for (var i = 0; i < resultList.Count; i++)
                    {
                        var x = resultList[i];
                        var t = x.GetType();
                        OrderByAttribute a = t.GetCustomAttributes(typeof(OrderByAttribute), false).FirstOrDefault() as OrderByAttribute;
                        var key = a?.Key;
                        if (string.IsNullOrEmpty(key)) { key = t.Name; }
                        if (string.Compare(key, attribute.After, true) == 0)
                        {
                            resultList.Insert(i, srcItem);
                            found = true;
                            break;
                        }
                    }
                }
                // Was not found, so add at end:
                if (found)
                {
                    continue;
                }
                resultList.Add(srcItem);
            }
            var results = resultList.ToArray();

            return results;

        }

    }
}