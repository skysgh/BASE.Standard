// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;

namespace App.Extensions
{
    /// <summary>
    ///     Methods that extend
    ///     <see cref="IModuleOdataModelBuilderConfiguration" />
    ///     instances.
    /// </summary>
    public static class IAppCoreOdataModelBuilderConfigurationExtensions
    {
        /// <summary>
        ///     Gets the controller name from the given Entity, by convention.
        ///     <para>
        ///         Eg: "Principal" gives "PrincipalsController"
        ///     </para>
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="dtoType">Type of the dto.</param>
        /// <param name="pluralise">if set to <c>true</c> [pluralise].</param>
        /// <returns></returns>
        public static string GetControllerNameByConvention(this IModuleOdataModelBuilderConfiguration x, Type dtoType,
            bool pluralise = true)
        {
            var className = dtoType.Name;

            //Strip off DTO first:
            var pos = className.IndexOf("dto", StringComparison.InvariantCultureIgnoreCase);
            if (pos > -1)
            {
                className = className.Substring(0, pos);
            }

            // Then pluralise...mostly... (Person...People, anyone?!?!)
            if (pluralise)
            {
                if (className.EndsWith("y"))
                {
                    // Assembly -> Assemblies
                    className = className.Substring(0, className.Length - 1) + "ies";
                }
                else if (className.EndsWith("s"))
                {
                    //Address -> Addresses
                    className = className + "es";
                }
                else
                {
                    // Cat,Fish,Foo,Bar,Action,Plate
                    className = className + "s";
                }
            }

            return className;
        }
    }
}