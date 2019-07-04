﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{

    public class AzureRedisCacheServiceConfiguration 
        : ConfigurationObjectBase
            , IHasServiceClientSecret
    {
        public AzureRedisCacheServiceConfiguration(
            AzureCommonConfigurationSettings azureCommonConfigurationSettings,
            IConfigurationService configurationService)
        {

configurationService.Get(this);

if (string.IsNullOrEmpty(this.ResourceName))
            {
                this.ResourceName = azureCommonConfigurationSettings.RootResourceName;
            }

        }

        public string ConnectionString
        {
            get { return _connectionString
                         ??(_connectionString = 
                $"{ResourceName}.redis.cache.windows.net, ssl = true, password = {ClientSecret}");
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
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureRedisCacheResourceName)]
        public string ResourceName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        ///     <para>
        ///         See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        ///         and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" />
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureRedisEnabled)]
        public bool Enabled
        {
            // Note that string type is intentional.
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        ///     <para>
        ///         Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" />
        ///     </para>
        ///     .
        /// </summary>
        [ConfigurationSettingSource(SourceType.KeyVault)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureRedisCacheDefaultAuthorizationKey)]
        public string ClientSecret { get; set; }

    }
}