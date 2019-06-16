using App.Modules.All.Shared.Initialization;
using Microsoft.AspNetCore.Mvc.Razor;

namespace App.Modules.All.AppFacade.Initialization.Views
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Initialization.IHasInitialize{RazorViewEngineOptions}" />
    public interface IAllModulesViewArtifactRegistration : IHasInitialize<RazorViewEngineOptions>
    {
    }
}
