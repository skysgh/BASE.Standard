// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using App.Modules.All.Shared.Constants;

namespace App
{
    /// <summary>
    ///     Extensions to <see cref="AppDomain" /> objects.
    /// </summary>
    public static class AppDomainExtensions
    {
        /// <summary>
        ///     Loads all assemblies specific to this application.
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        public static IEnumerable<Assembly> LoadAllAppAssemblies(this AppDomain appDomain)
        {
            List<Assembly> allAssemblies = new List<Assembly>();
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string[] files =
                Directory.GetFiles(path, $"{Application.AssemblyPrefix}*.dll")
                    .ToArray();

            var results = new List<Assembly>();
            files.ForEach(x => results.Add(Assembly.LoadFile(x)));

            return results;
        }

        public static Assembly[] GetAssemblies(this AppDomain appDomain,
            bool allAssemblies)
        {
            Assembly[] assemblies
                = allAssemblies
                    ? appDomain.GetAssemblies()
                    : appDomain.GetAssemblies().Where(x => x.IsSameApp())
                        .ToArray();

            return assemblies;

        }

        /// <summary>
        ///     Gets this application assemblies
        ///     (those that start with "App."
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        /// <returns></returns>
        public static Assembly[] GetAppAssemblies(this AppDomain appDomain)
        {
            var results = GetAssemblies(appDomain, false);

            return results;
        }


        /// <summary>
        /// Gets all derived instantiable types, instantiates them
        /// (using <see cref="Activator" /> - *not* <see cref="AppDependencyLocator" />!)
        /// then runs the new instance through the provided action.
        /// <para>
        /// Invoked at least when scanning for StructureMap scanners
        /// in all assemblies.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appDomain">The application domain.</param>
        /// <param name="func">The function.</param>
        /// <param name="allAssemblies">if set to <c>true</c> [all assemblies].</param>
        public static void InvokeImplementing<T>(this AppDomain appDomain, Action<T> func, bool allAssemblies = false)
        {
            foreach (var foundType in appDomain.GetInstantiableTypesImplementing(typeof(T), allAssemblies))
            {
                var tmp = (T) Activator.CreateInstance(foundType);
                func(tmp);
            }
        }

        public static IEnumerable<Type> GetContractsDecoratedByAttribute(
            this AppDomain appDomain, 
            Type contractType, 
            Type attributeType, 
            bool allBinAssemblies = false)
        {
            List<Type> results = new List<Type>();

            foreach (var assembly in appDomain.GetAssemblies(allBinAssemblies))
            {

                results.AddRange(assembly.GetContractsDecoratedByAttribute(
                    contractType,
                    attributeType));
            }

            return results;
        }


        /// <summary>
        /// Gets all derived instantiable types, within the domain.
        /// <para>
        /// An example use case would be to find all API Controllers
        /// in order to associate them with a specific version.
        /// </para></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appDomain">The application domain.</param>
        /// <param name="allAssemblies">if set to <c>true</c> [all assemblies].</param>
        /// <returns>
        /// the found types.
        /// </returns>
        public static IEnumerable<Type> GetInstantiableTypesImplementing<T>(
            this AppDomain appDomain,
            bool allAssemblies = false)
        {
            return appDomain.GetInstantiableTypesImplementing(typeof(T), allAssemblies);
        }


        /// <summary>
        /// Gets all derived instantiable types, within the domain.
        /// <para>
        /// An example use case would be to find all API Controllers
        /// in order to associate them with a specific version.
        /// </para></summary>
        /// <param name="appDomain">The application domain.</param>
        /// <param name="contractType">The type.</param>
        /// <param name="allAssemblies">if set to <c>true</c> [all assemblies].</param>
        /// <returns>
        /// the found types.
        /// </returns>
        public static IEnumerable<Type> GetInstantiableTypesImplementing(
            this AppDomain appDomain,
            Type contractType,
            bool allAssemblies = false)
        {
            List<Type> results = new List<Type>();

            Assembly[] assemblies = appDomain.GetAssemblies(allAssemblies);

            foreach (var assembly in assemblies)
            {

                IEnumerable<Type> r = assembly.GetInstantiableTypesImplementing(contractType);
                if (r == null)
                {
                    continue;
                }

                results.AddRange(r);
            }

            return results;
        }

        public static Type[] GetTypes(this AppDomain appDomain, Func<Type, bool> predicate, bool allAssemblies = false)
        {
            IList<Type> results = new List<Type>();

            Assembly[] assemblies = appDomain.GetAssemblies(allAssemblies);

            foreach (Assembly assembly in assemblies)
            {
                results.AddRange(assembly.GetTypes().Where(predicate));
            }
            return results.ToArray();
        }

        
        /// <summary>
        ///     Loads all assemblies in the bin directory.
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        public static void LoadAllBinDirectoryAssemblies(this AppDomain appDomain)
        {
            var binPath =
                Path.Combine(appDomain.BaseDirectory,
                    "bin"); // note: don't use CurrentEntryAssembly or anything like that.
            if (!Directory.Exists(binPath))
            {
                binPath = appDomain.BaseDirectory;
            }

            string[] filenames = Directory.GetFiles(binPath, "*.dll", SearchOption.AllDirectories);

            foreach (var fileName in filenames)
            {
                try
                {
                    var loadedAssembly = Assembly.LoadFile(fileName);
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (FileLoadException loadEx)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                } // The Assembly has already been loaded.
#pragma warning disable 168
                catch (BadImageFormatException imgEx)
#pragma warning restore 168
                {
                } // If a BadImageFormatException exception is thrown, the file is not an assembly.
            } // foreach dll
        }
    }
}