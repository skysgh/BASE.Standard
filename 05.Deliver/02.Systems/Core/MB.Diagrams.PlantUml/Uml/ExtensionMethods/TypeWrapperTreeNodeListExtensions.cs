// Copyright MachineBrains, Inc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using App.Diagrams.PlantUml.Models;
using App.Diagrams.PlantUml.Uml.Models;
using App.Diagrams.PlantUml.Uml.Services.Implemtations;
using XAct.Collections;

namespace App.Diagrams.PlantUml.Uml
{
    public static class TypeWrapperTreeNodeListExtensions
    {
        private delegate void Del2(TreeNode<string> namespaceNode);

        private delegate void Del(TreeNode<TypeWrapper> TreeNode, TreeNode<TypeWrapper> parentNode = null);


        /// <summary>
        /// A helper method to extract a Flat (ie a List) list of Packages describing Assemblies
        /// (and not their child Namespaces)
        /// </summary>
        /// <param name="diagramRenderingRequest"></param>
        /// <param name="baseTypeNodes"></param>
        /// <returns></returns>
        public static PackageClassDiagramElement[] DevelopListOfAssemblyPackagesFromProvidedTypeTree(
            this IEnumerable<TreeNode<TypeWrapper>> baseTypeNodes,
            DiagramRenderingRequest diagramRenderingRequest)
        {
            // Create a Flat array of Packages (non-nested)
            // Ensuring we're not adding what we don't need to add:
            var tmpPackages = new List<PackageClassDiagramElement>();

            foreach (var baseTypeNode in baseTypeNodes)
            {
                baseTypeNode.TrimTreeOfIgnoredTypes(diagramRenderingRequest.Types);
                baseTypeNode.TrimTreeBeyondBoundaryTypes(diagramRenderingRequest.Types);
                // Get package for Type, and all Parents.
                // Add to Flat List.
                // Note that this will often will lead to duplicates
                tmpPackages.Add(baseTypeNode.CreateAssemblyPackages(diagramRenderingRequest));
            }
            // remove duplicates:
            var packages = tmpPackages.DistinctBy(x => x.Title).ToArray();

            return packages;
        }



        public static void AssignTypesToAsssemblyPackages(this IEnumerable<TreeNode<TypeWrapper>> baseTypeNodes, DiagramRenderingStats diagramRenderingStats,
            PackageClassDiagramElement[] assemblyPackages)
        {
            var visited = new List<Type>();

            //Go through each incoming Entity, and assign to one of the
            // Assembly packages:

            // Note that we only created Assembly packages to assign Types to.
            foreach (var typeNode in baseTypeNodes)
            {
                foreach (var n in typeNode.SelfAndDescendants)
                {
                    // For some reason, someone has deemed that this type should not be displayed, 
                    // so we don't assign it to a Package:
                    if (!n.Value.Display)
                    {
                        continue;
                    }

                    // We've already assigned this Type to a Package, moving on:
                    if (visited.Contains(n.Value.Type))
                    {
                        continue;
                    }

                    // We know what Package to assign to:
                    var assembly = n.Value.Type.GetTypeInfo().Assembly.GetName().Name;
                    var package = assemblyPackages.Single(x => x.Title == assembly);
                    // So we create a Child Entity
                    // The CreateFrom method will determine whether to refer to it as
                    // a Class, Interface, abstract, etc.
                    package.Entities.Add(new ClassDiagramElement(diagramRenderingStats).CreateFrom(n.Value.Type));

                    // We record that we did this type already.
                    visited.Add(n.Value.Type);
                }
            }
        }








        public static ConstructorDependencyRelationshipClassDiagramElement[] DevelopConstructorRelationships(this IEnumerable<TreeNode<TypeWrapper>> baseTypeNodes)
        {
            List<ConstructorDependencyRelationshipClassDiagramElement> results =
                new List<ConstructorDependencyRelationshipClassDiagramElement>();


            foreach (var baseTypeNode in baseTypeNodes)
            {
                Type srcType = baseTypeNode.Value.Type;


                ConstructorInfo constructorInfo = srcType.GetConstructorWithMostArguments();
                if (constructorInfo == null)
                {
                    continue;
                }

                foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
                {

                    Type targetType = parameterInfo.ParameterType;

                    bool targetIsEnumerable = targetType.IsEnumerable() || targetType.IsArray;


                    while (targetType.IsGenericType)
                    {
                        targetType = targetType.GetGenericArguments().First();
                    }


                    if (targetType.IsPrimitive)
                    {
                        continue;
                    }

                    if ((targetType.FullName ?? targetType.Name).StartsWith("System."))
                    {
                        continue;
                    }


                    if (results.Any(x => x.Source == srcType && x.Target == targetType))
                    {
                        continue;
                    }

                    ConstructorDependencyRelationshipClassDiagramElement propRelationshipInfo = new ConstructorDependencyRelationshipClassDiagramElement(srcType, targetType);

                    //propRelationshipInfo.SourceIsEnumerable = srcType.IsEnumerable();
                    propRelationshipInfo.TargetIsEnumerable = targetIsEnumerable; // targetType.IsEnumerable();

                    results.Add(propRelationshipInfo);

                }
            }
            return results.ToArray();
        }




        public static PropertyRelationshipClassDiagramElement[] DevelopPropertyRelationships(this IEnumerable<TreeNode<TypeWrapper>> baseTypeNodes)
        {
            List<PropertyRelationshipClassDiagramElement> processed = new List<PropertyRelationshipClassDiagramElement>();


            foreach (var baseTypeNode in baseTypeNodes)
            {
                Type srcType = baseTypeNode.Value.Type;


                foreach (PropertyInfo propertyInfo in srcType.GetProperties())
                {
                    Type targetType = propertyInfo.PropertyType;
                    bool targetIsEnumerable = targetType.IsEnumerable() || targetType.IsArray;


                    while (targetType.IsGenericType)
                    {
                        targetType = targetType.GetGenericArguments().First();
                    }


                    if (targetType.IsPrimitive)
                    {
                        continue;
                    }

                    if ((targetType.FullName ?? targetType.Name).StartsWith("System."))

                    {
                        continue;
                    }


                    if (processed.Any(x => x.Source == srcType && x.Target == targetType))
                    {
                        continue;
                    }

                    PropertyRelationshipClassDiagramElement propRelationshipInfo = new PropertyRelationshipClassDiagramElement(srcType, targetType);

                    //propRelationshipInfo.SourceIsEnumerable = srcType.IsEnumerable();
                    propRelationshipInfo.TargetIsEnumerable = targetIsEnumerable;// targetType.IsEnumerable();

                    processed.Add(propRelationshipInfo);

                }
            }
            return processed.ToArray();
        }




        public static PackageClassDiagramElement[] DevelopAssemblyPackagesFromTypeConstructorAndPropertyRelationships(
                    this IEnumerable<TreeNode<TypeWrapper>> baseTypeNodes,
                    IEnumerable<PackageClassDiagramElement> packages,
                    DiagramRenderingStats renderingStats,
                    out TypeRelationshipDiagramElementBase[] typeRelationships)

        {

            List<PackageClassDiagramElement> results = new List<PackageClassDiagramElement>();

            // Get relationships from the given Types:
            List<TypeRelationshipDiagramElementBase> tmpRelationships =
                new List<TypeRelationshipDiagramElementBase>();
            tmpRelationships.AddRange(baseTypeNodes.DevelopConstructorRelationships());
            tmpRelationships.AddRange(baseTypeNodes.DevelopPropertyRelationships());

            // Iterate through relationships of Relationships
            foreach (var relationshipInfo in tmpRelationships)
            {
                var type = relationshipInfo.Target;

                //Get package from name of assembly within which *Target* type is found:
                var package = packages.SingleOrDefault(x => x.Title == type.GetTypeInfo().Assembly.GetName().Name);

                if (package != null)
                {
                    if (package.Entities.Any(x => x.FullName == type.GetName(true)))
                    {
                        continue;
                    }

                    package.Entities.Add(new ClassDiagramElement(renderingStats).CreateFrom(type));
                }
                else
                {
                    results.Add(
                        new PackageClassDiagramElement(renderingStats)
                        {
                            Title = type.GetTypeInfo().Assembly.GetName().Name
                        });
                }
            }

            typeRelationships = tmpRelationships.ToArray();
            return results.ToArray();
        }




        public static List<PackageClassDiagramElement> DevelopNamespacePackagesFromTypes(this List<TreeNode<TypeWrapper>> baseTypeNodes,
    DiagramRenderingRequest diagramRenderingRequest, bool addTypesToPackages)
        {
            //AA/BB/CC
            //AA
            //AA/DD/FF/GG
            //AA/DD/FF
            //BB
            //AA/CC
            //AA/BB/EE

            var processedTypes = new List<Type>();

            //The nested results:
            var results = new List<PackageClassDiagramElement>();
            //pointers to packages, but kept flat in order to scan more easily:
            var flatPackages = new List<PackageClassDiagramElement>();


            foreach (var baseTypeNode in baseTypeNodes)
            {
                baseTypeNode.TrimTreeOfIgnoredTypes(diagramRenderingRequest.Types);
                baseTypeNode.TrimTreeBeyondBoundaryTypes(diagramRenderingRequest.Types);

                var sortedNodes = baseTypeNode.SelfAndDescendants.OrderBy(x => x.Value.Type.Namespace.Length);

                foreach (var x in sortedNodes)
                {

                    var type = x.Value.Type;

                    if (processedTypes.Contains(type))
                    {
                        continue;
                    }

                    //Get the namespace of the source entity type:
                    var ns = type.Namespace;
                    //Break 'XAct.SubA.SubB' into 'XAct' 'SubA' 'SubB'
                    var nsParts = ns.Split('.');


                    var iMax = nsParts.Length;

                    PackageClassDiagramElement packageNode = null;

                    for (var i = iMax; i > -1; i--)
                    {

                        //Build up a Search text, from 'XAct' to 'XAct.Sub' to 'XAct.Sub.Sub'.
                        string nsSearchFor = String.Join(".", nsParts.Take(i).ToArray());
                        //Does it exist?
                        packageNode = flatPackages.SingleOrDefault(f => f.Title == nsSearchFor);

                        if (packageNode != null)
                        {
                            //found. But are we at 'XAct.SubA.SubB', or something shorter?
                            if (i < iMax)
                            {
                                //It is shorter -- add it
                                var tmp = new PackageClassDiagramElement(diagramRenderingRequest.RenderingStats) { Title = ns };

                                flatPackages.Insert(flatPackages.IndexOf(packageNode) + 1, tmp);
                                //Insert it into it's parent.
                                //We know there's no gap, as we sorted the list by name length 
                                //before we started.
                                packageNode.Packages.Add(tmp);
                                packageNode = tmp;
                            }
                            break;
                        }
                    }
                    if (packageNode == null)
                    {
                        packageNode = new PackageClassDiagramElement(diagramRenderingRequest.RenderingStats) { Title = ns };
                        results.Add(packageNode);
                        flatPackages.Add(packageNode);
                    }

                    //Add the Type to the package;
                    if (addTypesToPackages)
                    {
                        packageNode.Entities.Add(new ClassDiagramElement(diagramRenderingRequest.RenderingStats).CreateFrom(type));
                    }

                    processedTypes.Add(type);
                }
            }

            return results;
        }


        /// <summary>
        /// Delves into the given Types looking for parent objects
        /// etc.
        /// <para>
        /// This only is for Rendering when not in Namespaces or Assemblies.
        /// </para>
        /// </summary>
        /// <param name="baseTypeNodes"></param>
        /// <param name="diagramRenderingRequest"></param>
        /// <param name="stringBuilder"></param>
        public static void RenderTypesByDependencies( this
                                                        List<TreeNode<TypeWrapper>> baseTypeNodes,
                                                        DiagramRenderingRequest diagramRenderingRequest,
                                                        StringBuilder stringBuilder
            )
        {
            var diagramRenderingRequestTypes = diagramRenderingRequest.Types;

            List<Type> processedTypes = new List<Type>();

            foreach (TreeNode<TypeWrapper> baseTypeNode in baseTypeNodes)
            {
                baseTypeNode.TrimTreeOfIgnoredTypes(diagramRenderingRequestTypes);
                baseTypeNode.TrimTreeBeyondBoundaryTypes(diagramRenderingRequestTypes);

                TypeWrapperTreeNodeListExtensions.Del fu = null;
                fu = delegate (TreeNode<TypeWrapper> TreeNode, TreeNode<TypeWrapper> parentNode)
                {
                    if (processedTypes.Contains(TreeNode.Value.Type))
                    {
                        return;
                    }

                    if (diagramRenderingRequestTypes.Ignore.Contains(TreeNode.Value.Type))
                    {
                        return;
                    }

                    processedTypes.Add(TreeNode.Value.Type);

                    if (TreeNode.Value.Display)
                    {
                        stringBuilder.Append(new ClassDiagramElement(diagramRenderingRequest.RenderingStats).CreateFrom(TreeNode.Value.Type));
                        //Put some space between types:
                        stringBuilder.AppendLine("");
                    }

                    if (diagramRenderingRequestTypes.StopAt.Contains(TreeNode.Value.Type))
                    {
                        return;
                    }

                    foreach (var childNode in TreeNode.Children)
                    {
                        fu(childNode, TreeNode);
                    }

                };


                //Invoke the recursive method:
                fu.Invoke(baseTypeNode, null);


                //Put some space between this BaseType and next:
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("");
                stringBuilder.AppendLine("");

            }
        }


        public static List<string> RenderEntityInheritenceAndImplementationRelationships(this IEnumerable<TreeNode<TypeWrapper>> baseTypeNodes, StringBuilder stringBuilder)
        {

            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("'Entity Inheritence/Implementation Relationships:");
            stringBuilder.AppendLine("'-----------------------");

            List<string> results = new List<string>();

            foreach (var baseTypeNode in baseTypeNodes)
            {
                TypeWrapperTreeNodeListExtensions.Del fu = null;
                fu = delegate (TreeNode<TypeWrapper> TreeNode, TreeNode<TypeWrapper> parentNode)
                {
                    if (parentNode != null)
                    {
                        var parentType = parentNode.Value.Type.GetTypeInfo();
                        string connectionType = (parentType.IsInterface)
                                                    ? "<|.."
                                                    : "<|--";

                        var conStr = "\"{0}\" {1} \"{2}\"".FormatStringInvariantCulture(
                            TreeNode.Value.Type.GetName(true),
                            connectionType,
                            parentNode.Value.Type.GetName(true));

                        if (!results.Contains(conStr))
                        {
                            results.Add(conStr);
                        }
                    }

                    foreach (var childNode in TreeNode.Children)
                    {
                        fu(childNode, TreeNode);
                    }
                };


                //Invoke the recursive method:
                fu.Invoke(baseTypeNode, null);
            }

            foreach (string relationship in results)
            {
                stringBuilder.AppendLine(relationship);
            }

            return results;
        }
    }
}