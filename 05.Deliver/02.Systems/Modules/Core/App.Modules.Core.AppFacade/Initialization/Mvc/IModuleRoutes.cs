using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Shared.Contracts;
using Lamar;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.Core.AppFacade.Initialization.Mvc
{
    /// <summary>
    /// Contract for defining a single Module's
    /// Routes.
    /// <para>
    /// Invoked from Host Startup.
    /// </para> 
    /// </summary>
    public interface IModuleRoutes : IHasInitialize<IRouteBuilder>
    {

    }
}
