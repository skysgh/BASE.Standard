using App.Modules.Core.Shared.Contracts.Lifecycles;

namespace App.Modules.Core.Shared.Contracts.Lifecycles
{
    /// <summary>
    /// A Singleton version of <see cref="IHasLifecycle"/>.
    /// <para>
    /// At startup the IoC Container (ie, StructureMap)
    /// searches all assemblies for services, etc.
    /// and uses <see cref="IHasLifecycle"/> to hint as to how 
    /// to register them.
    /// </para>
    /// <para>
    /// Should be implemented by atleast all Services in the system.</para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Contracts.Lifecycles.IHasLifecycle" />
    public interface IHasSingletonLifecycle : IHasLifecycle
    {
    }
}


namespace App.Modules.Core.Shared.Contracts
{
}