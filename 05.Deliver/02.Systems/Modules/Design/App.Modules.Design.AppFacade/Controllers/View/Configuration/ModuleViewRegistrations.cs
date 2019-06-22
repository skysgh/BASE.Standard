// Copyright MachineBrains, Inc. 2019

using System.Reflection;
using App.Modules.All.AppFacade.Views.Configuration;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;

namespace App.Modules.Design.AppFacade.Controllers.View.Configuration
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <seealso cref="IAllModulesViewArtifactRegistration" />
    public class ModuleViewRegistrations : IAllModulesViewArtifactRegistration
    {
        /// <summary>
        ///     Initializes the specified razor view engine options.
        /// </summary>
        /// <param name="razorViewEngineOptions">The razor view engine options.</param>
        public void Initialize(RazorViewEngineOptions razorViewEngineOptions)
        {
            //Provide this Module's AppFacade Assembly
            var assembly = typeof(DescribeTypesController)
                .GetTypeInfo()
                .Assembly;

            razorViewEngineOptions.FileProviders.Add(
                new EmbeddedFileProvider(assembly));
        }
    }
}