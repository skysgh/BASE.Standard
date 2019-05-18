

namespace App.Diagrams.PlantUml.Uml
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;




    /// <summary>
    /// Extensions to <see cref="MethodInfo"/>
    /// </summary>
    /// <internal><para>8/7/2011: Sky</para></internal>
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// <para>
        /// An XActLib Extension.
        /// </para>
        /// Gets the signature of the method (a better implementation than the generic ToString()).
        /// <para>
        /// Used by <see cref="ITracingService"/>.
        /// </para>
        /// </summary>
        /// <param name="methodInfo">The methodInfo.</param>
        /// <param name="includeClassName">if set to <c>true</c> [include class name].</param>
        /// <returns></returns>
        /// <internal>8/7/2011: Sky</internal>
        public static string ToStringSignature(this MethodInfo methodInfo, bool includeClassName = false)
        {
            //includeParamValues = false;

            StringBuilder sb = new StringBuilder();

            if (methodInfo.IsPrivate)
            {
                sb.Append("private ");
            }
            else if (methodInfo.IsPublic)
            {
                sb.Append("public ");
            }
            if (methodInfo.IsAbstract)
            {
                sb.Append("abstract ");
            }
            if (methodInfo.IsStatic)
            {
                sb.Append("static ");
            }
            if (methodInfo.IsVirtual)
            {
                sb.Append("virtual ");
            }
            sb.Append(methodInfo.ReturnType.Name);
            sb.Append(" ");
            if (includeClassName)
            {
                sb.Append(methodInfo.ReflectedType.Name);
                sb.Append(".");
            }
            sb.Append(methodInfo.Name);
            sb.Append("(");
            String[] param;
            //Pretty sure this can't be done via reflection
            //if (includeParamValues)
            //{
            //    param =
            //    methodInfo.GetParameters()
            //        .Select(p => String.Format(
            //            "{0} {1}={2}", p.ParameterType.Name, p.Name))
            //        .ToArray();
            //}
            //else
            //{
            param =
                methodInfo.GetParameters()
                    .Select(p => String.Format(
                        "{0} {1}", p.ParameterType.Name, p.Name))
                    .ToArray();
            //}

            sb.Append(String.Join(", ", param));

            sb.Append(")");

            return sb.ToString();
        }



        /// <summary>
        /// Gets Attributes on the given <see cref="MethodInfo"/>.
        /// <para>
        /// The Default System has a recurse <see cref="bool"/> flag,
        /// but it doesn't do anything: no recursion takes place on 
        /// <see cref="MethodInfo"/> or <see cref="PropertyInfo"/> objects.
        /// </para>
        /// <para>
        /// This is a known issue. See: http://hyperthink.net/blog/getcustomattributes-gotcha/
        /// </para>
        /// <para>
        /// This method does.
        /// </para>
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="methodInfo"></param>
        /// <param name="recurse"></param>
        /// <returns></returns>
        public static TAttribute GetAttributeRecursively<TAttribute>(this MethodInfo methodInfo, bool recurse = true)
        where TAttribute : Attribute
        {
            TAttribute result = (TAttribute)methodInfo.GetAttributeRecursively(typeof(TAttribute), recurse);
            return result;
        }

        public static Attribute GetCustomAttribute(this MethodInfo methodInfo, Type attributeType, bool inherit = true)
        {
            Attribute[] resultAttributes = methodInfo.GetCustomAttributes(attributeType, inherit) as Attribute[];

            if ((resultAttributes == null) || (resultAttributes.Length == 0))
            {
                return null;
            }

            //Attribute resultAttribute = methodInfo.GetCustomAttribute(attributeType, recurse);
            Attribute resultAttribute = resultAttributes.First();

            return resultAttribute;

        }

        public static Attribute[] GetCustomAttributes(this MethodInfo methodInfo, Type attributeType, bool inherit = true)
        {
            Attribute[] resultAttributes = methodInfo.GetCustomAttributes(attributeType, inherit) as Attribute[];

            return resultAttributes;

        }



        /// <summary>
        /// Gets Attributes on the given <see cref="MethodInfo" />.
        /// <para>
        /// The Default System has a recurse <see cref="bool" /> flag,
        /// but it doesn't do anything: no recursion takes place on
        /// <see cref="MethodInfo" /> or <see cref="PropertyInfo" /> objects.
        /// </para>
        /// <para>
        /// This is a known issue. See: http://hyperthink.net/blog/getcustomattributes-gotcha/
        /// </para>
        /// <para>
        /// This method does.
        /// </para>
        /// </summary>
        /// <param name="methodInfo">The method information.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <param name="recurse">if set to <c>true</c> [recurse].</param>
        /// <returns></returns>
        public static Attribute GetAttributeRecursively(this MethodInfo methodInfo, Type attributeType, bool recurse = true)
        {
            Attribute[] attributes = methodInfo.GetAttributesRecursively(attributeType, recurse);

            if ((attributes == null) || (attributes.Length == 0))
            {
                return null;
            }

            return attributes.First();
        }

        public static TAttribute[] GetAttributesRecursively<TAttribute>(this MethodInfo methodInfo, bool recurse = true)
            where TAttribute : Attribute
        {
            return methodInfo.GetAttributesRecursively(typeof(TAttribute), recurse).Cast<TAttribute>().ToArray();
        }


        public static Attribute[] GetAttributesRecursively(this MethodInfo methodInfo, Type attributeType,
                                                                    bool recurse = true)
        {


            //Get the attributes on this Method:

            Attribute[] resultAttributes = (Attribute[])methodInfo.GetCustomAttributes(attributeType, recurse);

            //If there are any attibutes on this object, certainly no need to recurse higher
            //as it's expensive:
            if ((!recurse) || (resultAttributes != null) && (resultAttributes.Length > 0))
            {
                return resultAttributes;
            }

            //The Source method we are trying to match upong parent Methods, 
            //has parameters:
            ParameterInfo[] methodParameterInfos = methodInfo.GetParameters();


            //But if we must...
            foreach (Type parentClassType in methodInfo.DeclaringType.GetParentTypes())
            {

                if (!methodInfo.IsGenericMethod)
                {
                    //Easy when method has no generics:

                    //We use those to match to get the expected arguments:
                    Type[] methodArgumentTypes = methodParameterInfos.Select(p => p.ParameterType).ToArray();

                    //Which we use as filters for methods on the parent element.
                    MethodInfo parentMethodInfo =
                        parentClassType.GetMethod(methodInfo.Name, methodArgumentTypes);

                    if (parentMethodInfo == null)
                    {
                        //It's possible that this parent/anscestor 
                        //type doesn't sport this member:
                        continue;
                    }

                    //But if it does, get its attributes:
                    resultAttributes = parentMethodInfo.GetCustomAttributes(attributeType).ToArray();

                    if (resultAttributes != null)
                    {
                        //Found one (and even if there is ones on higher ones, this overrides them):
                        return resultAttributes;
                    }
                    //On to next parent class
                    continue;
                }
                else
                {
                    //Harder when dealing with generics:
                    MethodInfo[] parentMethodInfos =
                        parentClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                  .Where(mi => (mi.Name == methodInfo.Name)
                                               &&
                                               (mi.ContainsGenericParameters)
                                               &&
                                               (mi.ReturnType == methodInfo.ReturnType)
                                               &&
                                               (mi.GetParameters().Length == methodInfo.GetParameters().Length)
                                               &&
                                               (mi.GetCustomAttribute(attributeType) != null)
                            ).ToArray();

                    if (parentMethodInfos.Length == 0)
                    {
                        //No matches...or if there were, none had attributes...which is the same thing 
                        //in this case:
                        return null;
                    }
                    if (parentMethodInfos.Length == 1)
                    {
                        //Only one so don't have to bother matching params.
                        //And we know it has one:
                        resultAttributes = parentMethodInfos.First().GetCustomAttributes(attributeType).ToArray();
                        return resultAttributes;
                    }

                    //There are some matches....and they all have the right number parameters, return the right value type, and 
                    //have our Attribute...
                    //but which one to choose?
                    //Go by matching argument order and type:
                    bool match = true;

                    foreach (MethodInfo pMI in parentMethodInfos)
                    {
                        match = true;
                        ParameterInfo[] p = pMI.GetParameters();
                        ParameterInfo[] p2 = methodInfo.GetParameters();

                        for (int i = 0; i < p.Length; i++)
                        {
                            if (p[i].ParameterType != p2[i].ParameterType)
                            {
                                match = false;
                                break;
                            }
                        }
                        if (match)
                        {
                            //All params matched:
                            return pMI.GetCustomAttributes(attributeType).ToArray();
                        }
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// Determine if the Method is a get_ or set_ wrapper around a property.
        /// <para>
        /// We use this when reflecting over types to make UML and don't want to mistake Properties
        /// for methods.
        /// </para>
        /// </summary>
        public static bool IsPropertyAccessor(this MethodInfo methodInfo)
        {
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var result = methodInfo
                        .DeclaringType
                        .GetProperties(bindingFlags)
                        .Any(p => p.GetSetMethod() == methodInfo || p.GetSetMethod(true) == methodInfo || p.GetGetMethod() == methodInfo || p.GetGetMethod(true) == methodInfo);
            return result;
        }

        public static bool IsPublic(this MethodInfo methodInfo)
        {
            return methodInfo.IsPublic;
        }
        public static bool IsInternal(this MethodInfo methodInfo)
        {
            return (!(methodInfo.IsPublic | methodInfo.IsPrivate | methodInfo.IsFamily));
        }
        public static bool IsProtected(this MethodInfo methodInfo)
        {
            return methodInfo.IsFamily;
        }
        public static bool IsPrivate(this MethodInfo methodInfo)
        {
            return methodInfo.IsPrivate;
        }

        public static bool IsAbstract(this MethodInfo methodInfo)
        {
            return methodInfo.IsAbstract;
        }

        public static bool IsPublicAbstract(this MethodInfo methodInfo)
        {
            return methodInfo.IsPublic() && methodInfo.IsAbstract();
        }


    }
#if (!REMOVENS4EXTENSIONS)
    //See: http://bit.ly/snE0xY
}
#endif
