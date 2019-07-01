﻿// Copyright MachineBrains, Inc. 2019

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


        /// <summary>
        ///     Gets this application assemblies
        ///     (those that start with "App."
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        /// <returns></returns>
        public static IEnumerable<Assembly> GetAppAssemblies(this AppDomain appDomain)
        {
            IEnumerable<Assembly> results = appDomain.GetAssemblies().Where(x => x.IsSameApp());

            return results;
        }

        /// <summary>
        ///     Gets all derived instantiable types, instantiates them
        ///     (using <see cref="Activator" /> - *not* <see cref="AppDependencyLocator" />!)
        ///     then runs the new instance through the provided action.
        ///     <para>
        ///         Invoked at least when scanning for StructureMap scanners
        ///         in all assemblies.
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appDomain">The application domain.</param>
        /// <param name="func">The function.</param>
        public static void InvokeImplementing<T>(this AppDomain appDomain, Action<T> func)
        {
            foreach (var foundType in appDomain.GetInstantiableTypesImplementing(typeof(T)))
            {
                var tmp = (T) Activator.CreateInstance(foundType);

                func(tmp);
            }
        }


        /// <summary>
        ///     Gets all derived instantiable types, within the domain.
        ///     <para>
        ///         An example use case would be to find all API Controllers
        ///         in order to associate them with a specific version.
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appDomain">The application domain.</param>
        /// <returns>
        ///     the found types.
        /// </returns>
        public static IEnumerable<Type> GetInstantiableTypesImplementing<T>(this AppDomain appDomain)
        {
            return appDomain.GetInstantiableTypesImplementing(typeof(T));
        }


        /// <summary>
        ///     Gets all derived instantiable types, within the domain.
        ///     <para>
        ///         An example use case would be to find all API Controllers
        ///         in order to associate them with a specific version.
        ///     </para>
        /// </summary>
        /// <param name="appDomain">The application domain.</param>
        /// <param name="type">The type.</param>
        /// <returns>the found types.</returns>
        public static IEnumerable<Type> GetInstantiableTypesImplementing(this AppDomain appDomain, Type type)
        {
            List<Type> results = new List<Type>();
            Assembly[] tmp = appDomain.GetAssemblies();
            foreach (var assembly in tmp)
            {
                IEnumerable<Type> r = assembly.GetInstantiableTypesImplementing(type);
                if (r == null)
                {
                    continue;
                }

                results.AddRange(r);
            }

            return results;
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