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
            var result = System.Activator.CreateInstance<TConfigurationObject>();
            Get(result);
            return result;
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
            string moduleName =
                typeof(TConfigurationObject).GetModuleIdentifier();

            string configName = typeof(TConfigurationObject).Name;

            string sectionName = $"app:modules:{moduleName}:{configName}";

            if (_configuration.GetSection(sectionName).Exists())
            {
                _configuration.Bind(sectionName, target);
                return;
            }

            var suffix = "ConfigurationSettings";
            if (sectionName.EndsWith(suffix))
            {
                configName = typeof(TConfigurationObject).Name;
                configName =
                    configName.Substring(0, configName.Length - suffix.Length);
                sectionName = $"app:modules:{moduleName}:{configName}";

                if (_configuration.GetSection(sectionName).Exists())
                {
                    _configuration.Bind(sectionName, target);
                    return;
                }
            }

            suffix = "Settings";
            if (sectionName.EndsWith(suffix))
            {
                configName = typeof(TConfigurationObject).Name;
                configName =
                    configName.Substring(0, configName.Length - suffix.Length);
                sectionName = $"app:modules:{moduleName}:{configName}";

                if (_configuration.GetSection(sectionName).Exists())
                {
                    _configuration.Bind(sectionName, target);
                    return;
                }
            }
            suffix = "Configuration";
            if (sectionName.EndsWith(suffix))
            {
                configName = typeof(TConfigurationObject).Name;
                configName =
                    configName.Substring(0, configName.Length - suffix.Length);
                sectionName = $"app:modules:{moduleName}:{configName}";

                if (_configuration.GetSection(sectionName).Exists())
                {
                    _configuration.Bind(sectionName, target);
                    return;
                }
            }

        }
    }
}
