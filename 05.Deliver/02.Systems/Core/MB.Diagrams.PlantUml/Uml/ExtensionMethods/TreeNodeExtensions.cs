using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Diagrams.PlantUml.Uml
{
    using System.Globalization;
    using XAct.Collections;

    public static class TypeNodeExtensions
    {
        public static IEnumerable<T> Values<T>(this IEnumerable<TreeNode<T>> nodes)
        {
            return nodes.Select(n => n.Value);
        }
    }
}
