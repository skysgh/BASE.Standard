using System;
using System.Collections.Generic;
using System.Text;
using App.Modules.Core.Shared.Contracts;
using Lamar;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.Core.AppFacade.Initialization.Mvc
{
    public interface IModuleRoutes : IHasInitialize<IRouteBuilder>
    {

    }
}
