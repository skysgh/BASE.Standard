// Copyright MachineBrains, Inc.

using App.Diagrams.PlantUml;

namespace App.Diagrams.PlantUml.Uml.Models
{
    public abstract class RelationshipDiagramElementBase<T>
    {
        public string TypeName = "";
        protected string LineType = "..";
        protected string ArrowType = "";

        public RelationshipType Type { get; set; }
        public bool SourceIsEnumerable { get; set; }
        public bool TargetIsEnumerable { get; set; }
        public T Source { get; set; }
        public string SourceName { get; set; }
        public T Target { get; set; }
        public string TargetName { get; set; }

        protected RelationshipDiagramElementBase(T source, T target)
        {
            Source = source;
            Target = target;
        }

        public override string ToString()
        {
            string relationshipType = null;
            if (TargetIsEnumerable)
            {
                relationshipType = relationshipType + "o";
            }
            relationshipType = relationshipType + LineType;

            relationshipType = relationshipType + ArrowType;

            var result = "\"{0}\" {1} \"{2}\"".FormatStringInvariantCulture(SourceName, relationshipType, TargetName);

            return result;
        }
    }
}