using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Diagrams.PlantUml.Uml.Models;

namespace App.Diagrams.PlantUml.Uml
{
    public static class TypeRelationshipDiagramElementExtensions
    {

        public static void RenderTypeBasedRelationships(this TypeRelationshipDiagramElementBase[] relationshipInfo, StringBuilder stringBuilder)
        {
            if ((relationshipInfo == null) || (relationshipInfo.Length == 0))
            {
                return;
            }

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("'{0}s:".FormatStringInvariantCulture(relationshipInfo.First().TypeName));
            stringBuilder.AppendLine("'-----------------------");

            foreach (var p in relationshipInfo)
            {
                stringBuilder.AppendLine(p.ToString());
            }

        }



    }
}
