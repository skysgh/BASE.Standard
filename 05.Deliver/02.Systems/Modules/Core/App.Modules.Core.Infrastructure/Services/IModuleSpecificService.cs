namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Contracts;
    using App.Modules.Core.Shared.Contracts.Services;

    /// <summary>
    /// Contract for all Core Application Services.
    /// <para>
    /// The contract does not add or enforce any functionality
    /// bar specifying a specific IoC Lifecycle (making it a Singleton
    /// by inheriting from <see cref="IHasSingletonLifecycle"/>)
    /// and allowing for filtering per Core/Module.
    /// </para>
    /// </summary>
    /// <seealso cref="ISystemService" />
    public interface IModuleSpecificService : ISystemService
    {
    }
}