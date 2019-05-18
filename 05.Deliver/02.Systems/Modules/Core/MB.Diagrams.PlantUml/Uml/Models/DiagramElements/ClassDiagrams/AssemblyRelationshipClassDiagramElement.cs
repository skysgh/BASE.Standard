using System.Collections.Generic;
using System.Text;

namespace App.Diagrams.PlantUml.Uml.Models
{

    public class AssemblyRelationshipClassDiagramElement : RelationshipDiagramElementBase<string>
    {
        public AssemblyRelationshipClassDiagramElement(string source, string target)
            : base(source, target)
        {
            SourceName = source;
            TargetName = target;
            TypeName = "Assembly Reference Relationship";
            ArrowType = ">";
        }
    }
}
