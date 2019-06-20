using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a service that manages variables
    ///     within the current Operation's context. In a web app, that's
    ///     equivalent to the HttpContext.
    /// </summary>
    public interface IOperationContextService : IInfrastructureService
    {
        /// <summary>
        /// Gets the value of the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        T Get<T>(string key, T defaultValue = default(T));
        /// <summary>
        /// Sets the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Set<T>(string key, T value);
    }
}