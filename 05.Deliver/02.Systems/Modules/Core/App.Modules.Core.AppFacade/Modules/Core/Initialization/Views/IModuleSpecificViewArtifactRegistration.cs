using App.Modules.All.Shared.Initialization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace App.Modules.Core.Initialization.Views
{
    public interface IAllModulesViewArtifactRegistration : IHasInitialize<RazorViewEngineOptions>
    {
    }
}
