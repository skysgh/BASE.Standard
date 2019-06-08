// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.AppFacade.Controllers.Api.OData.Configuration;

namespace App.Extensions
{
    public static class IAppCoreOdataModelBuilderConfigurationExtensions
    {

        public static string GetControllerNameByConvention(this IAllModulesOdataModelBuilderConfiguration x, Type dtoType, bool pluralise=true)
        {
            string className = dtoType.Name;

            int pos = className.IndexOf("dto",StringComparison.InvariantCultureIgnoreCase);

            if (pos > -1)
            {
                className = className.Substring(0, pos);
            }

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