using Microsoft.Extensions.Configuration;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
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

        public TConfigurationObject Get<TConfigurationObject>()
        {
            var result = System.Activator.CreateInstance<TConfigurationObject>();
            Get(result);
            return result;
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="TConfigurationObject">The type of the configuration object.</typeparam>
        /// <returns></returns>
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
