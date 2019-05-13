using System;
using System.Collections.Generic;
using System.Text;
using App.Diagrams.PlantUml.Uml;

namespace App.Diagrams.PlantUml
{
    using System;


 
        public class TypeWrapper
        {
            /// <summary>
            /// The Type being investigated
            /// </summary>
            public Type Type { get; set; }
            //Whether to display this Type.
            private bool _display=true;

            /// <summary>
            /// The type will have to exist in the Type Tree --
            /// but maybe not displayed (ie, Excluded).
            /// </summary>
            public bool Display
            {
                get => _display;
                set => _display = value;
            }
            public TypeWrapper(Type type)
            {
                Type = type;
            }

            public override string ToString()
            {
                return "[{0}] {1}".FormatStringInvariantCulture((Display ? "*" : "-"), Type.Name.ToString());
            }
        }

    }


