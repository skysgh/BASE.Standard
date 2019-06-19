using App.Modules.All.Infrastructure.DependencyResolution;

namespace App.Modules.Design.Infrastructure.DependencyResolution
{
    /// <summary>
    /// A Lamar ServiceRegistry,
    /// scoped to this Module
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.DependencyResolution.ModuleServiceRegistryBase" />
    public class ModuleServiceRegistry : ModuleServiceRegistryBase
    {
        //Reuse common logic (filtering for local services).
    }
}