﻿// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Shared.Configuration.Settings;

namespace App.Modules.Core.Infrastructure.Services.Configuration.Implementations.AzureConfiguration
{
    public class AzureMapsServiceConfiguration : ICoreServiceConfigurationObject
    {
        public string
            RootUri =
                "https://atlas.microsoft.com"; // /search/address/reverse/json?subscription-key={subscription-key}&api-version=1.0&query={query}"


        public AzureMapsServiceConfiguration(IAzureKeyVaultService keyVaultService)
        {
            var commonConfigurationSettings = keyVaultService.GetObject<AzureCommonConfigurationSettings>();

            var configuration = keyVaultService.GetObject<AzureMapsConfigurationSettings>();

            if (string.IsNullOrEmpty(configuration.ResourceName))
            {
                configuration.ResourceName = commonConfigurationSettings.RootResourceName;
            }

            Key = configuration.Key;
        }

        public string Key { get; set; }
    }
}