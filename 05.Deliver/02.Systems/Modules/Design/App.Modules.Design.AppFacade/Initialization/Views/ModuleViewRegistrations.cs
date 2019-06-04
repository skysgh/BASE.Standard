using App.Modules.Core.AppFacade.Initialization.Views;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace App.Modules.Design.AppFacade.Initialization.Views
{
    public class ModuleViewRegistrations : IAllModulesViewArtifactRegistration
    {
        public void Initialize(RazorViewEngineOptions razorViewEngineOptions)
        {
            //Provide this Module's AppFacade Assembly
            var assembly = typeof(App.Modules.Core.AppFacade.Controllers.DescribeTypesController)
                        .GetTypeInfo()
                        .Assembly;

            razorViewEngineOptions.FileProviders.Add(
                new EmbeddedFileProvider(assembly));
        }
    }
}
