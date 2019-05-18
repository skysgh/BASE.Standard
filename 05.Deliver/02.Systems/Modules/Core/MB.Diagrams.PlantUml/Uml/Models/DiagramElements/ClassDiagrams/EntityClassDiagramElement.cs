using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Models;

namespace App.Diagrams.PlantUml.Uml
{
    using System.Collections.Generic;
    using System.Text;


    public class EntityClassDiagramElement
    {
        private readonly DiagramRenderingStats _diagramRenderingStats;
        public string ElementType { get; set; }

        /// <summary>
        /// The fullName of the Entity Type.
        /// Truncated when rendered within a Package, to save space.
        /// </summary>
        public string FullName { get; set; }


        protected EntityClassDiagramElement(string elemtnType, DiagramRenderingStats diagramRenderingStats)
        {
            _diagramRenderingStats = diagramRenderingStats;
            ElementType = elemtnType;
        }

        public List<EntityPropertyClassDiagramElement> Properties
        {
            get { return _properties ?? (_properties = new List<EntityPropertyClassDiagramElement>()); }
        }
        private List<EntityPropertyClassDiagramElement> _properties;

        public List<EntityMethodClassDiagramElement> Methods
        {
            get { return _methods ?? (_methods = new List<EntityMethodClassDiagramElement>()); }
        }
        private List<EntityMethodClassDiagramElement> _methods;




        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            // If we are not rendering packages, 
            // then we print the whole name.
            // Otherwise, we truncate.
            string showTitle = (_diagramRenderingStats.RenderingApproach == PackageRenderingType.None)
                ? FullName
                : FullName.Substring(FullName.LastIndexOf('.')+1);

            if (!string.IsNullOrEmpty(_diagramRenderingStats.LinkBaseUrl))
            {
                var url = _diagramRenderingStats.CreateSafeUrl(this.FullName);

                stringBuilder.AppendLine($"{ElementType} \"{showTitle}\"  as {FullName} [[{url} {showTitle}]] {{");
            }
            else
            {
                stringBuilder.AppendLine($"{ElementType} \"{showTitle}\" as {FullName} {{");
            }

            if (Properties.Any())
            {
                stringBuilder.AppendLine(" ".Repeat(2) + ".. Properties ..");
                foreach (var property in Properties.Take(_diagramRenderingStats.MaxPropertiesPerClass))
                {
                    stringBuilder.AppendLine("  " + property.ToString(this.ElementType == "interface"));
                }

                if (Properties.Count() > _diagramRenderingStats.MaxPropertiesPerClass)
                {
                    stringBuilder.AppendLine("  ...truncated...");
                }
            }

            if (Methods.Any())
            {
                stringBuilder.AppendLine(" ".Repeat(2) + ".. Methods ..");
                foreach (var method in Methods.Take(_diagramRenderingStats.MaxMethodsPerClass))
                {
                    stringBuilder.AppendLine(" ".Repeat(2) + method.ToString());
                }
                if (Methods.Count() > _diagramRenderingStats.MaxMethodsPerClass)
                {
                    stringBuilder.AppendLine("  ...truncated...");
                }
            }
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }


    }
}