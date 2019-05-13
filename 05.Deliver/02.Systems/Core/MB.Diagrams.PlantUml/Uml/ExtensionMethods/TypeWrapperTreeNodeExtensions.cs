using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using App.Diagrams.PlantUml.Models;
using XAct.Collections;

namespace App.Diagrams.PlantUml.Uml
{
    public static class TypeWrapperTreeNodeExtensions
    {

        public static void TrimTreeBeyondBoundaryTypes(this TreeNode<TypeWrapper> baseTypeNode, DiagramRenderingRequestTypes diagramRenderingRequestTypes)
        {
            foreach (var type in diagramRenderingRequestTypes.StopAt)
            {
                foreach (var typeFound in baseTypeNode.SelfAndDescendants.Where(x => x.Value.Type == type))
                {
                    while (typeFound.Children.Any())
                    {
                        typeFound.Children.Last().Disconnect();
                    }
                }
            }
        }

        public static void TrimTreeOfIgnoredTypes(this TreeNode<TypeWrapper> baseTypeNode, DiagramRenderingRequestTypes diagramRenderingRequestTypes )
        {
            // Remove types we're ignoring (ie, trim the image):
            foreach (var type in diagramRenderingRequestTypes.Ignore)
            {
                var tmp = baseTypeNode.SelfAndDescendants.SingleOrDefault(x => x.Value.Type == type);
                if (tmp != null)
                {
                    if (tmp.Parent != null)
                    {
                        tmp.Disconnect();
                    }
                }
            }
        }


        /// <summary>
        /// Builds a Flat List of Packages of all Assemblies
        /// related to the Types given.
        /// <para>
        /// Does not produce Packages for Namespaces.
        /// </para>
        /// </summary>
        /// <param name="baseTypeNode"></param>
        /// <param name="diagramRenderingRequest"></param>
        /// <returns></returns>
        public static IEnumerable<PackageClassDiagramElement> CreateAssemblyPackages(this TreeNode<TypeWrapper> baseTypeNode, DiagramRenderingRequest diagramRenderingRequest)
        {
            // Build a result
            // as a Flat list of Packages
            // obtained by building Packages around
            // the name Assembly extracted from the Type which the Type Wraps.
            // Ensure each Assembly only been added once.
            var packages =
                baseTypeNode
                    .SelfAndDescendants
                    .Select(x => new PackageClassDiagramElement(diagramRenderingRequest.RenderingStats)
                        { Title = x.Value.Type.GetTypeInfo().Assembly.GetName().Name })
                ;

            return packages;
        }
    }
}
