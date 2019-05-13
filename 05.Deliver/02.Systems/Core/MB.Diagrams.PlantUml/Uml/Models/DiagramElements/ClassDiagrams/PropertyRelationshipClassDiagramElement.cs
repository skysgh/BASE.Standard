// Copyright MachineBrains, Inc.

using System;

namespace App.Diagrams.PlantUml.Uml.Models
{
    public class PropertyRelationshipClassDiagramElement : TypeRelationshipDiagramElementBase
    {
        public PropertyRelationshipClassDiagramElement(Type sourceType, Type targetType)
            : base(sourceType, targetType)
        {


            TypeName = "Property Relationship";
            ArrowType = ">";
        }
    }
}