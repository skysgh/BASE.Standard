// Copyright MachineBrains, Inc.

using System;

namespace App.Diagrams.PlantUml.Uml.Models
{
    /// <summary>
    /// Used to record dependencies between classes
    /// and Dependencies that were
    /// Injected into Constructors.
    /// </summary>
    public class ConstructorDependencyRelationshipClassDiagramElement : TypeRelationshipDiagramElementBase
    {
        public ConstructorDependencyRelationshipClassDiagramElement(Type source, Type target)
            : base(source, target)
        {
            TypeName = "Constructor Dependency Relationship";
            ArrowType = ">";
        }
    }
}