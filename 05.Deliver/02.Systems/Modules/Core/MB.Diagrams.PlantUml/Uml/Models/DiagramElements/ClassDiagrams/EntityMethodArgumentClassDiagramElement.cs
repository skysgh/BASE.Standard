using MB.Diagrams.PlantUml;

namespace App.Diagrams.PlantUml.Uml
{
    using System;

    public class EntityMethodArgumentClassDiagramElement : IHasName
    {
        public string PropertyTypeName { get; set; }

        public string Name { get; set; }

        public EntityMethodArgumentClassDiagramElement(Type type, string name)
        {
            PropertyTypeName = type.GetName(false);
            Name = name;
        }
 
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMethodArgumentClassDiagramElement"/> class.
        /// </summary>
        /// <param name="propertyTypeName">Name of the property type.</param>
        /// <param name="name">The name.</param>
        public EntityMethodArgumentClassDiagramElement(string propertyTypeName, string name)
        {
            PropertyTypeName = propertyTypeName;
            Name = name;
        }
        public override string ToString()
        {
            return "{0} {1}".FormatStringInvariantCulture(PropertyTypeName, Name);
        }
    }
}