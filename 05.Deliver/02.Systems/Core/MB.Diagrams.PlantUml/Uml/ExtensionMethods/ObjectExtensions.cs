using System;
using System.Collections.Generic;
using System.Text;

namespace App.Diagrams.PlantUml.Uml
{
    public static class ObjectExtensions
    {
        public static IEnumerable<T> ToIEnumarable<T>(this T item)
        {
            yield return item;
        }
    }
}
