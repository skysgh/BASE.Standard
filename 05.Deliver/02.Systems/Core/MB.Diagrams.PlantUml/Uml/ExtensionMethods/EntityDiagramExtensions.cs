using App.Diagrams.PlantUml;

namespace App.Diagrams.PlantUml.Uml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using App.Diagrams.PlantUml.Uml;

    public static class EntityDiagramExtensions
    {

        public static EntityClassDiagramElement CreateFrom(this EntityClassDiagramElement entityDiagram, Type type)
        {

            if (type.GetTypeInfo().IsAbstract)
            {
                entityDiagram.ElementType = "abstract";
            }
            if (type.GetTypeInfo().IsInterface)
            {
                entityDiagram.ElementType = "interface";
            }
            entityDiagram.SetTitle(type.GetName(true));

            //Then Reflect over properties and methods:
            foreach (PropertyInfo propertyInfo in type.GetTypeInfo().DeclaredProperties)
            {
                entityDiagram.AddProperty(propertyInfo);
            }
            foreach (MethodInfo methodInfo in type.GetTypeInfo().DeclaredMethods)
            {
                if (methodInfo.IsPropertyAccessor())
                {
                    continue;
                }
                entityDiagram.AddMethod(methodInfo);
            }

            return entityDiagram;
        }


        public static EntityClassDiagramElement SetTitle(this EntityClassDiagramElement entityDiagram, string title)
        {
            entityDiagram.FullName = title;
            return entityDiagram;
        }

        public static EntityClassDiagramElement AddProperty(this EntityClassDiagramElement entityDiagram, PropertyInfo propertyInfo)
        {

            EntityDiagramMemberVisibility visibility =
                propertyInfo.CanRead | propertyInfo.CanWrite 
                    ? EntityDiagramMemberVisibility.Public
                          : EntityDiagramMemberVisibility.Private;

            entityDiagram.AddProperty(
                new EntityPropertyClassDiagramElement(
                    visibility,
                    propertyInfo.PropertyType.GetName(),
                    propertyInfo.Name,
                    propertyInfo.CanRead,
                    propertyInfo.CanWrite));

            return entityDiagram;
        }

        public static EntityClassDiagramElement AddProperty(this EntityClassDiagramElement entityDiagram,
                                                EntityPropertyClassDiagramElement entityDiagramProperty)
        {
            entityDiagram.Properties.Add(entityDiagramProperty);

            return entityDiagram;
        }

        public static EntityClassDiagramElement AddProperty(this EntityClassDiagramElement entityDiagram,
                                                EntityDiagramMemberVisibility visibility, Type propertyType,
                                                string propertyName, bool hasGetter = true, bool hasSetter = true)
        {
            entityDiagram.Properties.Add(new EntityPropertyClassDiagramElement(visibility, propertyType.GetName(), propertyName,
                                                                   hasGetter, hasSetter));

            return entityDiagram;
        }

        public static EntityClassDiagramElement AddProperty(this EntityClassDiagramElement entityDiagram,
                                                EntityDiagramMemberVisibility visibility, string propertyTypeName,
                                                string propertyName, bool hasGetter = true, bool hasSetter = true)
        {
            entityDiagram.Properties.Add(new EntityPropertyClassDiagramElement(visibility, propertyName, propertyName, hasGetter,
                                                                   hasSetter));

            return entityDiagram;
        }

        public static EntityClassDiagramElement AddMethod(this EntityClassDiagramElement entityDiagram, MethodInfo methodInfo)
        {

            AddMethod(entityDiagram, methodInfo.MapTo());

            return entityDiagram;
        }

        public static EntityMethodClassDiagramElement MapTo(this MethodInfo methodInfo)
        {
            EntityDiagramMemberVisibility visibility =
                methodInfo.IsPublicAbstract()
                ? EntityDiagramMemberVisibility.Abstract
                : methodInfo.IsPublic()
                    ? EntityDiagramMemberVisibility.Public
                    : methodInfo.IsInternal()
                        ? EntityDiagramMemberVisibility.Internal
                        : methodInfo.IsProtected()
                           ? EntityDiagramMemberVisibility.Protected
                           : EntityDiagramMemberVisibility.Private;

            var genericTypeNames = methodInfo.GetGenericArguments().Select(x => x.Name).ToArray();

            //var genericTypeNames = tmp.Where(x => x != null).Select(x => x.GetName()).ToArray();

            var parameterTypeNames = methodInfo
                .GetParameters()
                .Select(x => new EntityMethodArgumentClassDiagramElement(x.ParameterType.GetName(), x.Name)).ToArray();

            EntityMethodClassDiagramElement entityDiagramMethod = new EntityMethodClassDiagramElement(
                visibility,
                methodInfo.ReturnType.GetName(),
                methodInfo.Name,
                genericTypeNames,
                parameterTypeNames);

            return entityDiagramMethod;


        }

        public static EntityClassDiagramElement AddMethod(this EntityClassDiagramElement entityDiagram, EntityMethodClassDiagramElement entityDiagramMethod)
        {
            entityDiagram.Methods.Add(entityDiagramMethod);

            return entityDiagram;
        }

        public static EntityClassDiagramElement AddMethod(
            this EntityClassDiagramElement entityDiagram,
            EntityDiagramMemberVisibility visibility,
            Type returnPropertyType,
            string methodName,
            IEnumerable<string> typeParams,
            IEnumerable<EntityMethodArgumentClassDiagramElement> parameters)
        {
            return entityDiagram.AddMethod(visibility, returnPropertyType.GetName(), methodName, typeParams, parameters);
        }

        public static EntityClassDiagramElement AddMethod(this EntityClassDiagramElement entityDiagram,
                                              EntityDiagramMemberVisibility visibility,
                                              string returnPropertyType,
                                              string methodName,
                                              IEnumerable<string> typeParams,
                                              IEnumerable<EntityMethodArgumentClassDiagramElement> parameters)
        {
            entityDiagram.Methods.Add(new EntityMethodClassDiagramElement(visibility, returnPropertyType, methodName, typeParams,
                                                              parameters));

            return entityDiagram;
        }
    }
}
