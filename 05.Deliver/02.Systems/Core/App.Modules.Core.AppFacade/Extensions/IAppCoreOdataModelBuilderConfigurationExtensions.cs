// Copyright MachineBrains, Inc.

using System;
using App.Modules.Core.AppFacade.Initialization.OData;

namespace App
{
    public static class IAppCoreOdataModelBuilderConfigurationExtensions
    {

        public static string GetControllerNameByConvention(this IAllModulesOdataModelBuilderConfiguration x, Type dtoType)
        {
            string className = dtoType.Name;

            int pos = className.IndexOf("dto",StringComparison.InvariantCultureIgnoreCase);

            if (pos > -1)
            {
                className = className.Substring(0, pos - 1);
            }

            return className;

        }

    }
}