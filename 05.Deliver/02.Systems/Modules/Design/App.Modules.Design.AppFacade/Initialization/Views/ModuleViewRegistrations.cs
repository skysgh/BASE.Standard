using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using System.Reflection;
using App.Modules.Core.Initialization.Views;
using App.Modules.Design.AppFacade.Controllers;
using App.Modules.Design.AppFacade.Controllers.View;

namespace App.Modules.Design.AppFacade.Initialization.Views
{
    public class ModuleViewRegistrations : IAllModulesViewArtifactRegistration
    {
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
