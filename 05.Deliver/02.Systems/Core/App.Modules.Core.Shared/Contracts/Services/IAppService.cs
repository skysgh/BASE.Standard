using App.Modules.Core.Shared.Contracts.Lifecycles;

namespace App.Modules.Core.Shared.Contracts.Services
{

    /// <summary>
    /// Contract for all Application Services,
    /// across all Modules (where there are defined by their own Module
    /// specific contract -- eg: IModuleCoreService)
    /// <para>
    /// The contract does not add or enforce any functionality
    /// bar specifying a specific IoC Lifecycle (making it a Singleton
    /// by inheriting from <see cref="IHasSingletonLifecycle"/>).
    /// </para>
    /// </summary>
    /// <seealso cref="IHasSingletonLifecycle" />
    public interface IAppService : IHasSingletonLifecycle
    {
        // It is important to understand that 'Shared' 
        // will *not* have any Service *implementations*.
        // The contract is only here so that Services can be implemented 
        // in both Infrastructure, and Domain, without either knowing (ie
        // having a Reference) between the two.

        // This assembly is to remain light and dumb, basically only for 
        // Models, Messages, and tools to factory them
        // without referencing external services.
    }
}