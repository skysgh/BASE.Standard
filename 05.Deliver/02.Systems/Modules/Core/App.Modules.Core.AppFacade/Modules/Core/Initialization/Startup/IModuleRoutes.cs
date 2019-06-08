using App.Modules.All.Shared.Initialization;
using Microsoft.AspNetCore.Routing;

namespace App.Modules.Core.Initialization.Startup
{
    /// <summary>
    /// Contract for defining a single Module's
    /// Routes.
    /// <para>
    /// Invoked from Host Startup.cs
    /// </para> 
    /// </summary>
    public interface IModuleRoutes : IHasInitialize<IRouteBuilder>
    {

    }
}
