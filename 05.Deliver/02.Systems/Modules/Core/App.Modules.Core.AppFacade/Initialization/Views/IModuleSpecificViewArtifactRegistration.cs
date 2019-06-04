using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Shared.Contracts;
using Microsoft.AspNetCore.Mvc.Razor;

namespace App.Modules.Core.AppFacade.Initialization.Views
{
    public interface IAllModulesViewArtifactRegistration : IHasInitialize<RazorViewEngineOptions>
    {
    }
}
