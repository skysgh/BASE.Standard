// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Services.Configuration
{

    public class AzureRedisCacheServiceConfiguration
    : ServiceClientConfigurationObjectBase
    , IHasAzureResourceName
    , IHasConnectionString
    {
        public AzureRedisCacheServiceConfiguration(
            AzureEnvironmentSettings defaultAzureConfiguration,
            IConfigurationService configurationService)
        {

            configurationService.Get(this);

            if (string.IsNullOrEmpty(ResourceName))
            {
                ResourceName = defaultAzureConfiguration.DefaultResourceName;
            }

            if (BaseUri.IsNullOrEmpty())
            {
                BaseUri = $"{ResourceName}.redis.cache.windows.net";
            }

        }

        public string ConnectionString
        {
            get
            {
                return _connectionString
                       ?? (_connectionString =
                           $"{BaseUri}, ssl = true, password = {ClientSecret}"
                       );
            }
            set
            {
                _connectionString = value;
            }

        }
        private string _connectionString;



        /// <summary>
        ///     Gets or sets (from AppSettings)
        ///     the ResourceName of this StorageAccount.
        ///     <para>
        ///         <para>
        ///             If not provided in AppSettings, using
        ///             <see cref="ConfigurationKeys.AppCoreIntegrationAzureStorageAccountDefaultResourceName" />
        ///             falls back to
        ///             <see cref="ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName" />
        ///             plus 'di'.
        ///         </para>
        ///     </para>
        /// </summary>
        public string ResourceName { get; set; }


    }
}