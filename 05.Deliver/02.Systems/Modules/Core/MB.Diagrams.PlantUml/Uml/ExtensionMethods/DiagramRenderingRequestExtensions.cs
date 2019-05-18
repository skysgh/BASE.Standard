using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using App.Diagrams.PlantUml.Models;
using XAct.Collections;

namespace App.Diagrams.PlantUml.Uml
{
    public static class DiagramRenderingRequestExtensions
    {

        /// <summary>
        /// Get this Application's Assemblies, in order to find the most relevant types.
        /// </summary>
        /// <param name="diagramRenderingRequest"></param>
        /// <returns></returns>
        public static Assembly[] GetApplicationAssemblies(this DiagramRenderingRequest diagramRenderingRequest)
        {
            var applicationAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x =>
                x.FullName.StartsWith(diagramRenderingRequest.AssemblyNamePrefixFilter)).ToArray();

            return applicationAssemblies;

        }


        public static PackageClassDiagramElement[] DevelopAssemblyPackagesForProvidedTypes(this DiagramRenderingRequest diagramRenderingRequest, List<TreeNode<TypeWrapper>> baseTypeNodes, bool assignTypesToAssemblyPackages)
        {

            // Get List Packages for just Assemblies (not Namespaces)
            var assemblyPackages = baseTypeNodes.DevelopListOfAssemblyPackagesFromProvidedTypeTree(diagramRenderingRequest);

            if (assignTypesToAssemblyPackages)
            {
                // Assign Types, grossely, to Assemblies:
                baseTypeNodes.AssignTypesToAsssemblyPackages(diagramRenderingRequest.RenderingStats, assemblyPackages);
            }

            return assemblyPackages;

        }


    }
}
