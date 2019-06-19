using App.Modules.All.Domain;

namespace App.Modules.KWMODULE.Domain.Services
{
    /// <summary>
    /// Example of a Domain Service,
    /// invoked (along with Infrastructure Services)
    /// from an Infrastructure Service.
    /// </summary>
    /// <seealso cref="App.Modules.All.Domain.IDomainService" />
    public interface IExampleDomainService : IDomainService
    {
        /// <summary>
        /// Does something.
        /// </summary>
        /// <returns></returns>
        string DoSomething();
    }
}
