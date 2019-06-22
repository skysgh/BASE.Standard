// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration
{
    public class AzureRedisCacheServiceConfiguration : ICoreServiceConfigurationObject
    {
        public AzureRedisCacheServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();
            var configuration = keyVaultService.GetObject<AzureRedisCacheConfigurationSettings>();

            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            if (!bool.TryParse(configuration.Enabled, out var enabled))
            {
                enabled = true;
            }

            Enabled = enabled;
            ConnectionString =
                $"{configuration.ResourceName}.redis.cache.windows.net, ssl = true, password = {configuration.Key}";
        }

        public string ConnectionString { get; }

        public bool Enabled { get; }
    }
}