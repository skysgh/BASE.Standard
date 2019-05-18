using System;
using App.Diagrams.PlantUml.Models;

namespace App.Diagrams.PlantUml.Uml
{
    public class ClassDiagramElement : EntityClassDiagramElement
    {
        public ClassDiagramElement(DiagramRenderingStats diagramRenderingStats)
            : base("class", diagramRenderingStats)
        {

        }
    }

    public class AbstractClassDiagramElement : EntityClassDiagramElement
    {
        public AbstractClassDiagramElement(DiagramRenderingStats diagramRenderingStats)
            : base("abstract", diagramRenderingStats)
        {
        }
    }

    public class InterfaceDiagramElement : EntityClassDiagramElement
    {
        public InterfaceDiagramElement(DiagramRenderingStats diagramRenderingStats)
            : base("interface", diagramRenderingStats)
        {
        }
    }
}