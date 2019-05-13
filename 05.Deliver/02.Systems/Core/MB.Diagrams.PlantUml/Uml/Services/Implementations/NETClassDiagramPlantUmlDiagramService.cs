using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using App.Diagrams.PlantUml;
using App.Diagrams.PlantUml.Uml.Models;
using App.Diagrams.PlantUml.Models;

namespace App.Diagrams.PlantUml.Uml.Services.Implemtations
{
    using XAct.Collections;


    /// <summary>
    /// Contract for a service
    /// to render a Class Diagram.
    /// <para>
    /// Handles the build up of a requiest for types
    /// Invokes
    /// <see cref="IPlantUmlDiagramService"/>.
    /// </para>
    /// </summary>
    public class NetClassDiagramPlantUmlDiagramService : INetClassDiagramPlantUmlDiagramService
    {
        private readonly IPlantUmlDiagramService _plantUmlDiagramService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetClassDiagramPlantUmlDiagramService" /> class.
        /// </summary>
        /// <param name="plantUmlDiagramService">The plant uml diagram service.</param>
        public NetClassDiagramPlantUmlDiagramService(IPlantUmlDiagramService plantUmlDiagramService)
        {
            _plantUmlDiagramService = plantUmlDiagramService;
        }



        DiagramRenderingResponse RenderNamespaceFromGivenSearchTerm(DiagramRenderingRequest diagramRenderingRequest,
            string searchTerm, Assembly[] applicationAssemblies)
        {
            // Get 
            if (applicationAssemblies == null)
            {
                applicationAssemblies = diagramRenderingRequest.GetApplicationAssemblies();
            }

            foreach (var assembly in applicationAssemblies)
            {
                var typesStartingWithNamespaceName =
                    assembly
                        .GetTypes()
                        .Where(x => (x.Namespace ?? "")
                            .StartsWith(searchTerm, true, CultureInfo.InvariantCulture))
                        .ToArray();

                if (typesStartingWithNamespaceName.Any())
                {


                    // Some namespaces might contain too many Types to render efficiently:
                    diagramRenderingRequest.Types.Include =
                        typesStartingWithNamespaceName.Take(
                            diagramRenderingRequest.RenderingStats.MaxElementsPerPackage
                        ).ToArray();

                    // To save diagram space, we want Namespaces drawn,
                    // with types within having truncated names:
                    diagramRenderingRequest.RenderingStats.RenderingApproach =
                        PackageRenderingType.Namespace;

                    // Invoke Rendering of Type:
                    DiagramRenderingResponse diagramRenderingResponse =
                        this.Document(diagramRenderingRequest);

                    // Cleanup the title and metadata of response:
                    diagramRenderingResponse.DiagramTitle = assembly.FullName;
                    diagramRenderingResponse.ResponseType = DiagramRenderingResponseType.Assembly;

                    return diagramRenderingResponse;
                }

            }

            return null;
        }



        public DiagramRenderingResponse Document(DiagramRenderingRequest diagramRenderingRequest)
        {

            DiagramRenderingResponse result;

            if (diagramRenderingRequest.Types.Include.Length > 0)
            {
                result = RenderTypes(diagramRenderingRequest);
                return result;
            }

            // -----
            // Render App:
            // Rendering is based on what it finds, within string...
            // And it just might invoke Document(...) once it knows it's just rendering Types
            result = SearchForAndRenderSolutionAssemblies(diagramRenderingRequest);
            if (result != null)
            {
                return result;

            }
            // -----
            // Render Assembly:
            result = SearchForAndRenderSingleAssembly(diagramRenderingRequest);
            if (result != null)
            {
                return result;
            }
            // -----
            // Render Namespace:
            result = SearchForAndRenderSingleNamespace(diagramRenderingRequest);
            if (result != null)
            {
                return result;
            }
            // -----
            // Render Type:
            result = RenderTypes(diagramRenderingRequest);
            return result;

        }


        private DiagramRenderingResponse SearchForAndRenderSolutionAssemblies(DiagramRenderingRequest diagramRenderingRequest)
        {

            string searchTerm = diagramRenderingRequest.SearchTerm;
            var renderingStats = diagramRenderingRequest.RenderingStats;

            // We only Render Solution if searchTerm is empty 
            if ((!string.IsNullOrWhiteSpace(searchTerm)) && (searchTerm != diagramRenderingRequest.AssemblyNamePrefixFilter))
            {
                return null;
            }

            diagramRenderingRequest.RenderingStats.RenderingApproach = PackageRenderingType.Namespace;
            diagramRenderingRequest.RenderingStats.RenderingApproach = PackageRenderingType.Namespace;

            StringBuilder stringBuilder = renderingStats.InitializeStringBuilder();

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("'## Style For Non-Nesting:");
            stringBuilder.AppendLine("'-----------------------");
            stringBuilder.AppendLine("set namespaceSeparator none");


            // We're talking about all Application Assemblies.
            // Note that if no prefix given, we're talking about every Assembly.
            var assemblies = diagramRenderingRequest.GetApplicationAssemblies();
            // We want to get the core assemblies and render them as interlinked packages

            var appPackage = new PackageClassDiagramElement(renderingStats);
            appPackage.Title = diagramRenderingRequest.AssemblyNamePrefixFilter;
            appPackage.Stereotype = "Device";


            List<AssemblyRelationshipClassDiagramElement> relationships =
                new List<AssemblyRelationshipClassDiagramElement>();

            
            foreach (var assembly in assemblies)
            {
                var packageDiagram = assembly.CreateAssemblyPackage(renderingStats);
                packageDiagram.Title = assembly.GetName().Name;
                packageDiagram.Stereotype = "";

                appPackage.Packages.Add(packageDiagram);
                //Render package:

                // Add references between assemblies:
                var newRelationships = assembly.GetReferencedAssemblies().Where(
                        ra => assemblies.Any(y => ra.FullName == y.FullName))
                    .Select(x => new AssemblyRelationshipClassDiagramElement(assembly.GetName().Name, x.Name));
                relationships.AddRange(newRelationships);

            }
            // Turns out that some Relationships may point to 
            // Packages not already found above, so have to add them:
            foreach(var r in relationships)
            {
                if (!appPackage.Packages.All(x => x.Title != r.SourceName))
                {
                    continue;
                }

                var errataPackage = new PackageClassDiagramElement(diagramRenderingRequest.RenderingStats);
                errataPackage.Title = r.TargetName;
                appPackage.Packages.Add(errataPackage);
            }
            foreach (var r in relationships)
            {
                if (!appPackage.Packages.All(x => x.Title != r.TargetName))
                {
                    continue;
                }

                var errataPackage = new PackageClassDiagramElement(diagramRenderingRequest.RenderingStats);
                errataPackage.Title = r.TargetName;
                appPackage.Packages.Add(errataPackage);
            }

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("'## Assembly Packages:");
            stringBuilder.AppendLine("'-----------------------");
            stringBuilder.Append(appPackage);

            // Render Relationships:
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("'## Assembly Relationships:");
            stringBuilder.AppendLine("'-----------------------");
            foreach (var relationshipInfo in relationships)
            {
                var tmp = relationshipInfo.ToString();
                stringBuilder.AppendLine(relationshipInfo.ToString());
            }
            stringBuilder.AppendLine("");

            DiagramRenderingResponse result =
                InvokePlantUmlAndDevelopResult(renderingStats, stringBuilder);

            return result;

        }
        private DiagramRenderingResponse SearchForAndRenderModules(
            DiagramRenderingRequest diagramRenderingRequest)
        {
            return null;
        }


        private DiagramRenderingResponse SearchForAndRenderSingleModule(
            DiagramRenderingRequest diagramRenderingRequest)
        {
            return null;
        }


        private DiagramRenderingResponse SearchForAndRenderSingleAssembly(DiagramRenderingRequest diagramRenderingRequest)
        {
            string searchTerm = diagramRenderingRequest.SearchTerm;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Nothing to Search for:
                return null;
            }

            // The first question is whether we're talking about an Assembly
            var applicationAssemblies = diagramRenderingRequest.GetApplicationAssemblies();
            var assembly = applicationAssemblies.FirstOrDefault(x => x.GetName().Name.EndsWith(searchTerm));

            // Get out early to move on to next search:
            if (assembly == null)
            {
                return null;
            }


            // Develop new output, prepared with SVG and Styling:
            StringBuilder stringBuilder =
                diagramRenderingRequest.RenderingStats.InitializeStringBuilder();


            // We First need to create a Package for the Assembly:
            var assemblyPackage =
                assembly.CreateAssemblyPackage(
                    diagramRenderingRequest.RenderingStats);

            assemblyPackage.Stereotype = "Rectangle";

            // Convert the assembly's list of types into a type tree,
            // and subclasses, but
            // leaving off interfaces to keep it simple:
            var baseTypeNodesList = DevelopTreeOfDiscoveredTypes(assembly.GetTypes(), includeSubTypes: false, hideInterfaces: true);

            // We really only wanted the type list to be able to easily generate packages.

            // (which we do, but without adding Types to them):
            List<PackageClassDiagramElement> namespacePackageDiagramElements =
                baseTypeNodesList.DevelopNamespacePackagesFromTypes(diagramRenderingRequest, 
                    false);

            // Which we add to the Assemby package:
            assemblyPackage.Packages.AddRange(namespacePackageDiagramElements);


            // The results are a list, as there may be multiple root namespaces.
            // Each root package, will contain child packages. And Types.
            // Some namespaces might contain too many Types to render efficiently:

            foreach (var rootPackageDiagramElement in namespacePackageDiagramElements)
            {
                // Should not have any, but still: Don't want child packages:
                //rootPackageDiagramElement.Packages.Clear();

            }

            // Just the top assembly package:
            stringBuilder.Append(assemblyPackage.ToString());

            // That's it. Convert StringBuilder to output.
            DiagramRenderingResponse result =
                InvokePlantUmlAndDevelopResult(diagramRenderingRequest.RenderingStats, stringBuilder);

            return result;
        }




        private DiagramRenderingResponse SearchForAndRenderSingleNamespace(DiagramRenderingRequest diagramRenderingRequest)
        {
            var searchTerm = diagramRenderingRequest.SearchTerm;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Nothing to Search for:
                return null;
            }



            // Get 
            var applicationAssemblies = diagramRenderingRequest.GetApplicationAssemblies();

            Type[] foundTypes = null;
            foreach (Assembly assembly in applicationAssemblies)
            {
                foundTypes =
                    assembly.GetTypes()
                        .Where(x =>
                            string.Compare(searchTerm, x.Namespace, CultureInfo.InvariantCulture,
                                CompareOptions.IgnoreCase) == 0)
                        .ToArray();

                if (foundTypes.Length > 0)
                {
                    break;
                }
            }
            // Get out early if no Namespaces found:
            if ((foundTypes == null) || (foundTypes.Length == 0))
            {
                return null;
            }

            // Develop a simple list of Type nodes:
            var baseTypeNodesList = DevelopTreeOfDiscoveredTypes(foundTypes, true, true);

            // So that we can determine the Packages to render
            // And add the types to them:
            List<PackageClassDiagramElement> namespacePackageDiagramElements =
                baseTypeNodesList.DevelopNamespacePackagesFromTypes(diagramRenderingRequest, true);

            // The results are a list, as there may be multiple root namespaces.
            // Each root package, will contain child packages. And Types.

            // Develop new output, prepared with SVG and Styling:
            StringBuilder stringBuilder =
                diagramRenderingRequest.RenderingStats.InitializeStringBuilder();

            // And render to it:
            foreach (var rootPackageDiagramElement in namespacePackageDiagramElements)
            {
                // Should not have any, but still: Don't want child packages:
                rootPackageDiagramElement.Packages.Clear();

                //And if we're talking about any package that does not have the current namespace, then we also want it cleared:
                if (string.Compare(rootPackageDiagramElement.Title, searchTerm, CultureInfo.InvariantCulture,
                        CompareOptions.IgnoreCase) == 0)
                {
                    // Render package and it's child types:
                    stringBuilder.Append(rootPackageDiagramElement.ToString());
                }
                else
                {
                    // although may we want this pacakge, pointing to other (cleared) namspaces...
                    // in which case we  Clear 'other' package of types:
                    rootPackageDiagramElement.Entities.Clear();

                    // and still render it
                    stringBuilder.Append(rootPackageDiagramElement.ToString());
                }

            }

            // That's it. Convert StringBuilder to output.
            DiagramRenderingResponse result =
                InvokePlantUmlAndDevelopResult(diagramRenderingRequest.RenderingStats, stringBuilder);

            return result;
        }





        public DiagramRenderingResponse SearchForAndRenderSingleType(DiagramRenderingRequest diagramRenderingRequest)
        {
            var searchTerm = diagramRenderingRequest.SearchTerm;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                // Nothing to Search for:
                return null;
            }

            var applicationAssemblies = diagramRenderingRequest.GetApplicationAssemblies();

            Type[] foundTypes = null;
            foreach (Assembly assembly in applicationAssemblies)
            {
                foundTypes =
                    assembly.GetTypes()
                        .Where(x =>
                            string.Compare(searchTerm, x.FullName, CultureInfo.InvariantCulture,
                                CompareOptions.IgnoreCase) == 0)
                        .ToArray();

                if (foundTypes.Length > 0)
                {
                    break;
                }
            }
            // Get out early if no types found:
            if ((foundTypes == null) || (foundTypes.Length == 0))
            {
                return null;
            }

            diagramRenderingRequest.SearchTerm = null;

            diagramRenderingRequest.Types.Include = foundTypes;

            DiagramRenderingResponse result =
                RenderTypes(diagramRenderingRequest);

            return result;

        }

        private DiagramRenderingResponse RenderTypes(DiagramRenderingRequest diagramRenderingRequest)
        {
            StringBuilder stringBuilder =
                diagramRenderingRequest.RenderingStats.InitializeStringBuilder();

            DocumentTypes(diagramRenderingRequest, stringBuilder);

            // That's it. Convert StringBuilder to output.
            DiagramRenderingResponse result =
                InvokePlantUmlAndDevelopResult(diagramRenderingRequest.RenderingStats, stringBuilder);

            return result;
        }



        /// <summary>
        /// Whereas <see cref="RenderTypes"/> produces the whole output,
        /// this method just outputs the uml to a stringBuilder.
        /// </summary>
        /// <param name="diagramRenderingRequest"></param>
        /// <param name="stringBuilder"></param>
        private void DocumentTypes(DiagramRenderingRequest diagramRenderingRequest, StringBuilder stringBuilder)
        {
            // Develop a List of Trees of TypeWrappers
            // describing the ancestry of the Types provided in 
            // diagramRenderingRequest.
            // In other words, if you start with "SomeService", 
            // by the end of this you'll have a tree of
            // something like:
            // SomeService, ISomeService, IAppServices, ISingletonLifespan, ILifespan.
            var baseTypeNodes = DevelopTreeOfDiscoveredTypes(diagramRenderingRequest.Types);


            switch (diagramRenderingRequest.RenderingStats.RenderingApproach)
            {
                // The easiest rendering is just iterate through the List of Trees of Types
                // and just dump them out, and their relationship between them:
                case PackageRenderingType.None:
                    RenderTypesWithNoPackages(stringBuilder, baseTypeNodes, diagramRenderingRequest);
                    break;
                // Next up is iterating through the Types, 
                // to create Packages, and then render items within the Packages:
                case PackageRenderingType.Namespace:
                    RenderTypesWithNamespacePackages(stringBuilder, baseTypeNodes, diagramRenderingRequest);
                    break;
                case PackageRenderingType.Assembly:
                    RenderTypesWithAssemblyPackages(stringBuilder, baseTypeNodes, diagramRenderingRequest);
                    break;
            }

            //TreeNode<string>[] packageNames = null;
            //if (packageNames != null)
            //{

            //    foreach (var packageName in packageNames)
            //    {
            //        Del2 f = null;
            //        f = delegate(TreeNode<string> node)
            //                {
            //                    stringBuilder.AppendLine(
            //                        "{0} package {1} {{".FormatStringInvariantCulture(" ".Repeat(node.Level), node.Value));
            //                    foreach (var sn in node.Children)
            //                    {
            //                        f.Invoke(sn);
            //                    }
            //                    stringBuilder.AppendLine("}");
            //                };
            //        f.Invoke(packageName);
            //    }
            //}





        }


        /// <summary>
        /// This is generally a first step.
        /// 
        /// In other words, if you start with "SomeService", 
        /// by the end of this you'll have a tree of
        /// something like:
        /// SomeService, ISomeService, IAppServices, ISingletonLifespan, ILifespan.
        ///
        /// The result is a list because
        /// have been provided with n Types,
        /// which probably do not have a common ancestor.
        /// </summary>
        /// <param name="diagramRenderingRequestTypes"></param>
        private static List<TreeNode<TypeWrapper>> DevelopTreeOfDiscoveredTypes(
            DiagramRenderingRequestTypes diagramRenderingRequestTypes,
            bool includeSubTypes = true,
            bool hideInterfaces = false)
        {
            return DevelopTreeOfDiscoveredTypes(diagramRenderingRequestTypes.Include, includeSubTypes, hideInterfaces);
        }

        /// <returns></returns>
        private static List<TreeNode<TypeWrapper>> DevelopTreeOfDiscoveredTypes(Type[] types, bool includeSubTypes = true, bool hideInterfaces = false)
        {
            // Create a Tree of TypeWrappers to describe the set of discovered types:
            List<TreeNode<TypeWrapper>> baseTypeNodes = new List<TreeNode<TypeWrapper>>();

            // Develop a Tree from the Types defined in the provided diagramRenderingRequest:
            foreach (Type type in types)
            {
                TreeNode<TypeWrapper> baseTypeNode =
                    type.DevelopTypeTreeNode(includeSubTypes, hideInterfaces: hideInterfaces);

                baseTypeNodes.Add(baseTypeNode);
            }

            return baseTypeNodes;
        }

        private void RenderTypesWithAssemblyPackages(StringBuilder stringBuilder,
                                                List<TreeNode<TypeWrapper>> baseTypeNodes,
                                                DiagramRenderingRequest diagramRenderingRequest)
        {
            DiagramRenderingStats renderingStats = diagramRenderingRequest.RenderingStats;

            stringBuilder.AppendLine("set namespaceSeparator none");

            // Note converting to Mutable list 
            // because although Source is in list, Target's Assembly may not be.
            var assemblyPackages =
                diagramRenderingRequest.DevelopAssemblyPackagesForProvidedTypes(
                    baseTypeNodes,
                    true)
                    .ToList();

            // New Packages specific to the targets of the relationships:
            TypeRelationshipDiagramElementBase[] typeRelationshipInfos;



            var relationshipTargetAssemblyPackages =
                baseTypeNodes.DevelopAssemblyPackagesFromTypeConstructorAndPropertyRelationships(
                    assemblyPackages,
                    renderingStats,
                    out typeRelationshipInfos);
            // Any any newly discovered Assemblies to the known Source Assemblies list:
            assemblyPackages.AddRange(relationshipTargetAssemblyPackages);
            // And then cleanup duplicates:
            assemblyPackages = assemblyPackages.DistinctBy(x => x.Title).ToList();

            // Render packages:
            foreach (var package in assemblyPackages)
            {
                var tmp = package.ToString();

                stringBuilder.Append(package);
                stringBuilder.AppendLine("");
            }

            baseTypeNodes.RenderEntityInheritenceAndImplementationRelationships(stringBuilder);

            typeRelationshipInfos.RenderTypeBasedRelationships(stringBuilder);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="baseTypeNodes"></param>
        /// <param name="diagramRenderingRequest"></param>
        private void RenderTypesWithNamespacePackages(StringBuilder stringBuilder,
            List<TreeNode<TypeWrapper>> baseTypeNodes,
            DiagramRenderingRequest diagramRenderingRequest)
        {
            stringBuilder.AppendLine("set namespaceSeparator none");


            List<PackageClassDiagramElement> namespacePackages =
                baseTypeNodes.
                    DevelopNamespacePackagesFromTypes(
                    diagramRenderingRequest,
                    true);

            foreach (PackageClassDiagramElement packageDiagram in namespacePackages.Take(5))
            {
                stringBuilder.AppendLine(packageDiagram.ToString());
            }

            if (namespacePackages.Count > 5)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("note as NP0");
                stringBuilder.AppendLine(" Too many packages (truncated).");
                stringBuilder.AppendLine("end note");
            }

            baseTypeNodes.RenderEntityInheritenceAndImplementationRelationships(stringBuilder);

            //TODO: go through relationships, and add to packageDiagrams:
            RenderRelationshipsBetweenTypesBasedOnProperties(baseTypeNodes, stringBuilder);
        }





        /// <summary>
        /// Render the diagram with no packages,
        /// each class showing its full name.
        /// <para>
        /// Better suited for documenting a single class
        /// showing its interfaces, etc.
        /// </para>
        /// <para>
        /// Its really the simplest diagramming solution as it just rotates
        /// through the Types given, finds the relationships.
        /// </para>
        /// </summary>
        /// <param name="stringBuilder"></param>
        /// <param name="baseTypeNodes"></param>
        /// <param name="diagramRenderingRequest"></param>
        private void RenderTypesWithNoPackages(StringBuilder stringBuilder, List<TreeNode<TypeWrapper>> baseTypeNodes,
            DiagramRenderingRequest diagramRenderingRequest)
        {
            stringBuilder.AppendLine("set namespaceSeparator none");

            baseTypeNodes.RenderTypesByDependencies(diagramRenderingRequest, stringBuilder);

            baseTypeNodes.RenderEntityInheritenceAndImplementationRelationships(stringBuilder);

            RenderRelationshipsBetweenTypesBasedOnProperties(baseTypeNodes, stringBuilder);
        }



        private static void RenderRelationshipsBetweenTypesBasedOnProperties(
            List<TreeNode<TypeWrapper>> baseTypeNodes,
            StringBuilder stringBuilder)
        {
            var propRelationships = baseTypeNodes.DevelopPropertyRelationships();

            propRelationships.RenderTypeBasedRelationships(stringBuilder);
        }








        /// <summary>
        /// Convert the provided stringBuilder into an image/svg
        /// and return it.
        /// </summary>
        /// <param name="diagramRenderingRequest"></param>
        /// <param name="stringBuilder"></param>
        /// <returns></returns>
        private DiagramRenderingResponse InvokePlantUmlAndDevelopResult(DiagramRenderingStats diagramRenderingStats, StringBuilder stringBuilder)
        {
            var result = new DiagramRenderingResponse();


            result.DiagramText = stringBuilder.ToString();
            result.DiagramImageUrl = _plantUmlDiagramService.DevelopImageUrl(result.DiagramText);
            result.DiagramImage = _plantUmlDiagramService.RetrieveImageAsByteArray(result.DiagramText);

            if (diagramRenderingStats.ImageOutputType == DiagramRenderingRequestImageType.Svg)
            {
                //result.Svg = BitConverter.ToString(result.Image);
                string svg = System.Text.Encoding.UTF8.GetString(result.DiagramImage);
                XmlDocument x = new XmlDocument();
                x.InnerXml = svg;
                result.DiagramSvg = x.DocumentElement.OuterXml;
            }

            return result;
        }
    }
}
