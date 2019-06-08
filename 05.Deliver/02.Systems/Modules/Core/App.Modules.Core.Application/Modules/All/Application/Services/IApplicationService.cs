using App.Modules.All.Shared.Services;

namespace App.Modules.All.Application.Services
{
    /// <summary>
    /// Optional contract that all Application Services
    /// should inherit from.
    /// <para>
    /// The contract does not add or enforce any functionality
    /// bar specifying a specific IoC Lifecycle (making it a Singleton
    /// by inheriting from
    /// <see cref="App.Modules.All.Shared.DependencyResolution.Lifecycles.IHasSingletonLifecycle"/>)
    /// and allowing for filtering per Core/Module.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Services.ISystemService" />
    public interface IApplicationService : ISystemService
    {
    }
}
