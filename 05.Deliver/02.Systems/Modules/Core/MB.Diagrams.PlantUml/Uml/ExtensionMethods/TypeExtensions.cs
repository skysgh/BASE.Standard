using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using XAct.Collections;

namespace App.Diagrams.PlantUml.Uml
{
    public static class TypeExtensions
    {

        /// <summary>
        /// Gets the name of a Generic Type such that instead of returning
        /// <c>Dictionary`2 stuff)</c> or <c>List`1[]</c>
        /// it returns:
        /// <code>
        /// <![CDATA[
        /// ]]></code>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetName(this Type type, bool keepFullNames = false)
        {
            StringBuilder retType = new StringBuilder();

            if (type.IsArray)
            {
                var result = GetName(type.GetElementType()) + "[]";
                return result;
            }

            if (!type.IsGenericType)
            {
                return keepFullNames ? type.FullName : type.Name;
            }
            string rootType = (keepFullNames ? (type.FullName ?? type.Name) : type.Name).Split('`')[0];

            StringBuilder argList = new StringBuilder();

            // We will build the type here.
            Type[] genericArgumentTypes = type.GetGenericArguments();


            foreach (Type argumentType in genericArgumentTypes)
            {
                // Let's make sure we get the argument list.
                string arg = argumentType.GetName();

                if (argList.Length <= 0)
                {
                    argList.Append(arg);
                }
                else
                {
                    argList.AppendFormat(", {0}", arg);
                }
            }

            if (argList.Length > 0)
            {
                retType.AppendFormat("{0}<{1}>", rootType, argList.ToString());
            }
            else
            {
                retType.Append(type.ToString());
            }

            return retType.ToString();
        }

        /// <summary>
        /// Determines whether given type implements the given interface.
        /// </summary>
        /// <typeparam name="TInterfaceType">The type of the interface type.</typeparam>
        /// <param name="instanceType">Type of the instance.</param>
        /// <returns></returns>
        public static bool ImplementsInterface<TInterfaceType>(
            this Type instanceType)
        {
            return instanceType.ImplementsInterface(typeof(TInterfaceType));
        }


        /// <summary>
        /// Determines whether given type implements the given interface.
        /// </summary>
        /// <param name="instanceType">Type of the instance.</param>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <returns></returns>
        public static bool ImplementsInterface(this Type instanceType, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
            {
                return false;

            }
            return interfaceType.IsAssignableFrom(instanceType);
        }

        /// <summary>
        /// Gets the constructor with the most arguments.
        /// <para>
        /// In most cases this will be the constructor that will
        /// be referenced by a Dependency Injector.  
        /// </para>
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns></returns>
        public static ConstructorInfo GetConstructorWithMostArguments(this Type type,
            BindingFlags bindingFlags =
                BindingFlags.Instance | BindingFlags.Public |
                BindingFlags.NonPublic)
        {
            var constructors =
                type.GetConstructors(bindingFlags);

            ConstructorInfo constructorInfo =
                constructors.Aggregate((i1, i2) => i1.GetParameters().Count() > i2.GetParameters().Count() ? i1 : i2);

            return constructorInfo;
        }




        /// <summary>
        /// <para>
        /// An XActLib Extension.
        /// </para>
        ///   Determines whether the specified entity type is enumerable.
        /// </summary>
        /// <param name = "entityType">The entity type.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity type is enumerable; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEnumerable(this Type entityType)
        {
            return typeof(IEnumerable).IsAssignableFrom(entityType);
        }


        public static TreeNode<TypeWrapper> DevelopTypeTreeNode(this Type type, bool includeSubClasses = true,
            bool hideInterfaces = false, Type[] excludeSubTypes = null)
        {
            TreeNode<TypeWrapper> treeNode = new TreeNode<TypeWrapper>(new TypeWrapper(type));

            if (includeSubClasses)
            {
                GetSubclassesAndInterfacesX(treeNode, hideInterfaces, excludeSubTypes);
            }
            return treeNode;
        }
        private static TreeNode<TypeWrapper> GetSubclassesAndInterfacesX(TreeNode<TypeWrapper> treeNode, bool hideInterfaces = false,
                                                        Type[] excludeSubTypes = null)
        {

            // Exclude should certainly contain 'object'
            // so that not all other entities point back to it.
            if (excludeSubTypes == null)
            {
                excludeSubTypes = new[] { typeof(object) };
            }

            List<Type> excludes = new List<Type>();
            excludes.Add(excludeSubTypes);

            var alreadyAdded = new List<Type>();
            
            InternalRecursiveGetSubclassesAndInterfaces(treeNode, treeNode, ref excludes, ref alreadyAdded, hideInterfaces);

            return treeNode;
        }

        /// <summary>
        /// Recursive call to get a tree of Sub classes and (optionally) Interfaces
        /// </summary>
        /// <param name="sourceNode"></param>
        /// <param name="rootNode"></param>
        /// <param name="exclude"></param>
        /// <param name="alreadyAdded"></param>
        /// <param name="hideInterfaces"></param>
        /// <returns></returns>
        private static bool InternalRecursiveGetSubclassesAndInterfaces(this TreeNode<TypeWrapper> sourceNode, TreeNode<TypeWrapper> rootNode, ref List<Type> exclude, ref List<Type> alreadyAdded, bool hideInterfaces = false)
        {


            Type type = sourceNode.Value.Type;

            if (exclude.Contains(type))
            {
                //Probably a System.Object, which we don't need:
                return false;
            }

            //We have current Type -- we want to work upwards:
            Type baseType = type.BaseType;

            if (baseType != null)
            {
                var baseTypeNode = new TreeNode<TypeWrapper>(new TypeWrapper(baseType));


                //Depth First:
                if (baseTypeNode.InternalRecursiveGetSubclassesAndInterfaces(rootNode, ref exclude, ref alreadyAdded, hideInterfaces))
                {
                    if (hideInterfaces)
                    {
                        if (alreadyAdded.Contains(baseTypeNode.Value.Type))
                        {
                            baseTypeNode.Value.Display = false;
                        }
                    }

                    alreadyAdded.Add(baseTypeNode.Value.Type);

                    sourceNode.Add(baseTypeNode);
                }
            }


            //We want recursive interfaces:
            foreach (var tn in type.GetImmediateInterfaces())
            {
                var interfaceTypeNode = new TreeNode<TypeWrapper>(new TypeWrapper(tn));


                if (interfaceTypeNode.InternalRecursiveGetSubclassesAndInterfaces(rootNode, ref exclude, ref alreadyAdded, hideInterfaces))
                {
                    if (hideInterfaces)
                    {
                        if (alreadyAdded.Contains(interfaceTypeNode.Value.Type))
                        {
                            interfaceTypeNode.Value.Display = false;
                        }
                    }
                    alreadyAdded.Add(interfaceTypeNode.Value.Type);

                    sourceNode.Add(interfaceTypeNode);
                }
            }



            return true;
        }

        public static TreeNode<Type>[] GetInterfaceInheritence(this Type type)
        {
            List<TreeNode<Type>> results = new List<TreeNode<Type>>();

            //Given Foo, get IFoo
            foreach (Type interfaceType in type.GetImmediateInterfaces())
            {

                TreeNode<Type> subInterfaceNode = new TreeNode<Type>(interfaceType);
                //Get IBoo
                foreach (var t in interfaceType.GetInterfaceInheritence())
                {
                    subInterfaceNode.Add(t);
                }
                //[IFoo]:
                results.Add(subInterfaceNode);
            }
            return results.ToArray();
        }



        public static IEnumerable<Type> GetImmediateInterfaces(this Type type)
        {
            var interfaces = type.GetInterfaces();
            var result = new HashSet<Type>(interfaces);
            foreach (Type i in interfaces)
            {
                result.ExceptWith(i.GetInterfaces());
            }
            return result;
        }



        /// <summary>
        /// Gets the parent types.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="sort">if set to <c>true</c> [sort].</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetParentTypes(this Type type, bool sort = false)
        {
            List<Type> results = new List<Type>();

            if (type != null && type.BaseType != null)
            {
                //Do Instances First:
                for (Type currentBaseType = type.BaseType;
                    currentBaseType != null;
                    currentBaseType = currentBaseType.BaseType)
                {
                    results.Add(currentBaseType);
                }
                //Then interfaces:
                results.AddRange(type.GetInterfaces());
            }
            return sort ? results.TopologicalSort((x) => x.GetParentTypes()) : results;
            //return results;
        }



        public static TAttribute GetCustomAttribute<TAttribute>(this Type type, bool inherit = true)
            where TAttribute : class
        {
            return type.GetCustomAttribute(typeof(TAttribute), inherit) as TAttribute;
        }


        public static Attribute GetCustomAttribute(this Type type, Type attributeType, bool inherit = true)
        {
            Attribute[] resultAttributes = type.GetCustomAttributes(attributeType, inherit) as Attribute[];

            if ((resultAttributes == null) || (resultAttributes.Length == 0))
            {
                return null;
            }

            //Attribute resultAttribute = type.GetCustomAttribute(attributeType, recurse);
            Attribute resultAttribute = resultAttributes.First();

            return resultAttribute;

        }


    }
}
