// Copyright MachineBrains, Inc. 2019

using App.Modules.All.AppFacade.DependencyResolution;
using App.Modules.All.Shared.Initialization;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.All.AppFacade.Controllers.Configuration.Routes
{
    /// <summary>
    ///     Contract for defining a single Module's
    ///     Controller Routes (ie, Api, Views, OData).
    ///     <para>
    ///     Scanned for and found by <see cref="AllModulesAppFacadeServiceRegistry"/>
    ///     </para>
    ///     <para>
    ///         Then Invoked from the Host's Startup.cs
    ///     </para>
    /// </summary>
    public interface IModuleRoutes : IHasInitialize<IRouteBuilder>
    {
    }
}