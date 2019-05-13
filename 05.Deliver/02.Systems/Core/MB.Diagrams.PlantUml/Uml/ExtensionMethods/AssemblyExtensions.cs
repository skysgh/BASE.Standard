using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using App.Diagrams.PlantUml.Models;

namespace App.Diagrams.PlantUml.Uml
{
    public static class AssemblyExtensions
    {

        public static PackageClassDiagramElement CreateAssemblyPackage(this Assembly assembly, DiagramRenderingStats renderingStats)
        {
            PackageClassDiagramElement packageDiagram;
            packageDiagram = new PackageClassDiagramElement(renderingStats);
            packageDiagram.Title = assembly.GetName().Name;
            return packageDiagram;
        }

    }
}
