using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IConfigurationService"/>
    /// to return configuration objects (most often developed
    /// from <c>IConfigurationObject</c>) hydrated from
    /// values within appsettings.json, keyvault, etc.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IConfigurationService" />
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationService"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public ConfigurationService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Gets a new instance of <see cref="TConfigurationObject" />,
        /// hydrated with values from the <c>appsettings.json</c>, keyvault, etc.
        /// </summary>
        /// <typeparam name="TConfigurationObject">The type of the configuration object.</typeparam>
        /// <returns></returns>
        public TConfigurationObject Get<TConfigurationObject>()
        {
            return _configuration.Get<TConfigurationObject>();
        }

        /// <summary>
        /// Hydrates the given<see cref="TConfigurationObject" />,
        /// with values from the <c>appsettings.json</c>, keyvault, etc.
        /// <para>
        /// Often invoked within the Constructor of singleton
        /// configuration objects
        /// that derive from
        /// <c>IConfigurationObject"</c>.
        /// </para>
        /// </summary>
        /// <typeparam name="TConfigurationObject">The type of the configuration object.</typeparam>
        /// <param name="target">The target.</param>
        public void Get<TConfigurationObject>(TConfigurationObject target)
        {
            _configuration.Get<TConfigurationObject>(target);
        }
    }
}
