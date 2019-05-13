// Copyright MachineBrains, Inc.

using System;

namespace App.Diagrams.PlantUml.Uml.Models
{
    public abstract class TypeRelationshipDiagramElementBase : RelationshipDiagramElementBase<Type>
    {
        protected TypeRelationshipDiagramElementBase(Type source, Type target) : base(source, target)
        {
            SourceName = source.FullName ?? source.Name;
            TargetName = target.FullName ?? target.Name;
        }
    }
}