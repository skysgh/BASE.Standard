
using MB.Diagrams.PlantUml;

namespace App.Diagrams.PlantUml.Uml
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EntityPropertyClassDiagramElement
    {
        public EntityDiagramMemberVisibility Visibility { get; set; }
        public string PropertyType { get; set; }
        public string Name { get; set; }
        public bool HasGetter { get; set; }
        public bool HasSetter { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyClassDiagramElement"/> class.
        /// </summary>
        /// <param name="visibility">The visibility.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="name">The name.</param>
        /// <param name="hasGetter">if set to <c>true</c> [has getter].</param>
        /// <param name="hasSetter">if set to <c>true</c> [has setter].</param>
        public EntityPropertyClassDiagramElement(EntityDiagramMemberVisibility visibility, Type propertyType, string name,
                                     bool hasGetter = true, bool hasSetter = true)
            : this(visibility, propertyType.GetName(false), name, hasGetter, hasSetter)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyClassDiagramElement"/> class.
        /// </summary>
        /// <param name="visibility">The visibility.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="name">The name.</param>
        /// <param name="hasGetter">if set to <c>true</c> [has getter].</param>
        /// <param name="hasSetter">if set to <c>true</c> [has setter].</param>
        public EntityPropertyClassDiagramElement(EntityDiagramMemberVisibility visibility, string propertyType, string name,
                                     bool hasGetter = true, bool hasSetter = true)
        {
            Visibility = visibility;
            PropertyType = propertyType;
            Name = name;
            HasGetter = hasGetter;
            HasSetter = hasSetter;
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool isInterface)
            {
            StringBuilder stringBuilder = new StringBuilder();

            if (!isInterface)
            {
                switch (Visibility)
                {
                    case EntityDiagramMemberVisibility.Abstract:
                        stringBuilder.Append("{abstract} +");
                        break;
                    case EntityDiagramMemberVisibility.Public:
                        stringBuilder.Append("+");
                        break;
                    case EntityDiagramMemberVisibility.Internal:
                        stringBuilder.Append("~");
                        break;
                    case EntityDiagramMemberVisibility.Protected:
                        stringBuilder.Append("#");
                        break;
                    case EntityDiagramMemberVisibility.Private:
                        stringBuilder.Append("-");
                        break;
                }
            }
            stringBuilder.Append(" ");
            stringBuilder.Append(Name);


            stringBuilder.Append(" : ");
            stringBuilder.Append(PropertyType);

            stringBuilder.Append(" {");
            if (HasGetter) { stringBuilder.Append("get;"); }
            if (HasGetter && HasSetter) { stringBuilder.Append(" "); }
            if (HasSetter) { stringBuilder.Append("set;"); }
            stringBuilder.Append("}");




            return stringBuilder.ToString();
        }
    }
}