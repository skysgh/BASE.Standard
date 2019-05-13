using System;
using System.Linq;
using App.Diagrams.PlantUml.Models;

namespace App.Diagrams.PlantUml.Uml
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A Package can contain
    /// child Packages and
    /// child Types
    /// </summary>
    public class PackageClassDiagramElement
    {
        private static int counter = 0;

        private string _stereotype = "";

        public string Stereotype
        {
            get => _stereotype;
            set => _stereotype = value;
        }

        private readonly DiagramRenderingStats _diagramRenderingStats;

        public PackageClassDiagramElement(DiagramRenderingStats diagramRenderingStats)
        {
            _diagramRenderingStats = diagramRenderingStats;
        }

        /// <summary>
        /// The displayed Title of the Package.
        /// </summary>
        public string Title { get; set; }

        public List<PackageClassDiagramElement> Packages
        {
            get { return _packages ?? (_packages = new List<PackageClassDiagramElement>()); }
        }
        private List<PackageClassDiagramElement> _packages;

        public List<EntityClassDiagramElement> Entities
        {
            get { return _entities ?? (_entities = new List<EntityClassDiagramElement>()); }
        }
        private List<EntityClassDiagramElement> _entities;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            // If we are rendering Packages, and not just the content types and packages
            // (which too will will not be rendered), then we draw the wrapping brackets:

            string tmpStereotype = string.IsNullOrWhiteSpace(Stereotype) ? "" : $"<<{Stereotype}>>";

            if (!string.IsNullOrWhiteSpace(_diagramRenderingStats.LinkBaseUrl))
            {
                string clickableLink = string.Format(_diagramRenderingStats.LinkBaseUrl, Title);
                string line = $"package {Title} {tmpStereotype} [[{clickableLink}]] {{";
                stringBuilder.AppendLine(line);
            }
            else
            {
                string line = $"package {Title} {tmpStereotype} {{";
                stringBuilder.AppendLine(line);
            }


            RenderChildEntities(stringBuilder);

            RenderChildPackages(stringBuilder);


            if (_diagramRenderingStats.RenderingApproach != PackageRenderingType.None)
            {
                stringBuilder.AppendLine("}");
            }

            return stringBuilder.ToString();
        }

        private void RenderChildEntities(StringBuilder stringBuilder)
        {
            int Max = _diagramRenderingStats.MaxElementsPerPackage;
            foreach (var entity in Entities.Take(Max))
            {
                stringBuilder.AppendLine(entity.ToString());
            }

            if (Entities.Count > _diagramRenderingStats.MaxElementsPerPackage)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"note as NC{counter++}");
                stringBuilder.AppendLine(" Too many entities (truncated).");
                stringBuilder.AppendLine("end note");
            }
        }

        private void RenderChildPackages(StringBuilder stringBuilder)
        {
            int Max = _diagramRenderingStats.MaxElementsPerPackage;
            foreach (var package in Packages.Take(Max))
            {
                stringBuilder.AppendLine(package.ToString());
            }

            if (Packages.Count > Max)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine($"note as NP{counter++}");
                stringBuilder.AppendLine(" Too many packages (truncated).");
                stringBuilder.AppendLine("end note");
            }
        }
    }
}