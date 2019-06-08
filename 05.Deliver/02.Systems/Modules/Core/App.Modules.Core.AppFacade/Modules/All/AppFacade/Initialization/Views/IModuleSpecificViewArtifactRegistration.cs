using App.Modules.All.Shared.Initialization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace App.Modules.All.AppFacade.Initialization.Views
{
    public interface IAllModulesViewArtifactRegistration : IHasInitialize<RazorViewEngineOptions>
    {
    }
}
