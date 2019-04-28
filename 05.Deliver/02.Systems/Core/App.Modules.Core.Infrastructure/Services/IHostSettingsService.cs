namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Contracts.Services;



    /// <summary>
    /// Contract for an common Infrastructure Service to 
    /// manage Host specific, immutable Settings
    /// (commonly this wraps web.config, etc. settings
    /// that were injected at deployment time by the 
    /// Build Engine).
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IImmutableSetingsService" />
    /// <seealso cref="IAppModuleCoreService" />
    public interface IHostSettingsService : IImmutableSetingsService, IAppModuleCoreService
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