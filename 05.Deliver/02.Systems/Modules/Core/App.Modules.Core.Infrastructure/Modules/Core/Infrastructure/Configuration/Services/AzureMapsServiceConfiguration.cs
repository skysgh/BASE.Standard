// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Configuration;
using App.Modules.All.Shared.Attributes;
using App.Modules.All.Shared.Attributes.Enums;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Configuration.Settings;
using App.Modules.Core.Infrastructure.Services;
using App.Modules.Core.Shared.Constants;

namespace App.Modules.Core.Infrastructure.Configuration.Services
{
    public class AzureMapsServiceConfiguration 
        : ConfigurationObjectBase
            , IHasServiceClientSecret
    {
        public string
            RootUri =
                "https://atlas.microsoft.com"; // /search/address/reverse/json?subscription-key={subscription-key}&api-version=1.0&query={query}"


        public AzureMapsServiceConfiguration(
            AzureCommonConfigurationSettings azureCommonConfigurationSettings,
            IConfigurationService configurationService
            )
        {


            configurationService.Get(this);

            if (string.IsNullOrEmpty(this.ResourceName))
            {

                this.ResourceName =
                    azureCommonConfigurationSettings.RootResourceName;
            }

        }


        /// <summary>
        ///     Gets or sets (from AppSettings)
        ///     the ResourceName of this Map service.
        ///     <para>
        ///         <para>
        ///             If not provided in AppSettings, using
        ///             <see cref="ConfigurationKeys.AppCoreIntegrationAzureMapsDefaultResourceName" />
        ///             falls back to
        ///             <see cref="Shared.Constants.ConfigurationKeys.AppCoreIntegrationAzureCommonResourceName" />
        ///             plus 'di'.
        ///         </para>
        ///     </para>
        /// </summary>
        [ConfigurationSettingSource(SourceType.AppSetting)]
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureMapsDefaultResourceName)]
        public string ResourceName { get; set; }

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
        [Alias(ConfigurationKeys.AppCoreIntegrationAzureMapsDefaultAuthorizationKey)]
        public string ClientSecret { get; set; }

    }
}