using App.Modules.All.Infrastructure.Services;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    /// Contract for an common Infrastructure Service to 
    /// manage Host specific, immutable Settings
    /// (commonly this wraps web.config, etc. settings
    /// that were injected at deployment time by the 
    /// Build Engine).
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IImmutableSetingsService" />
    /// <seealso cref="IInfrastructureService" />
    public interface IHostSettingsService : IImmutableSetingsService, IInfrastructureService
    {
        /// <summary>
        ///     Create a Configuration object and fill properties from Host Settings with the same name.
        ///     <para>
        ///         Note that default values are not provided if the property value = default(T)
        ///     </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix"></param>
        /// <returns></returns>
        T GetObject<T>(string prefix = null) where T : class;
    }
}