// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureMapsService : AppCoreServiceBase, IAzureMapsService
    {
        private readonly IAzureDeploymentEnvironmentService _azureDeploymentEnvironmentService;
        private readonly AzureMapsServiceConfiguration _azureMapsServiceConfiguration;
        private readonly IRestService _restService;

        public AzureMapsService(AzureMapsServiceConfiguration azuresMapServiceConfiguration,
            IAzureDeploymentEnvironmentService azureDeploymentEnvironmentService, IRestService restService)
        {
            _azureMapsServiceConfiguration = azuresMapServiceConfiguration;
            _azureDeploymentEnvironmentService = azureDeploymentEnvironmentService;
            _restService = restService;
        }

        public AzureMapsSearchResponse AddressSearch(string searchTerm, string countrySetCsv, bool typeAhead = true)
        {
            var subscriptionKey = _azureMapsServiceConfiguration.ClientSecret;

            var uri = new Uri(
                _azureMapsServiceConfiguration.RootUri
                + $"/search/address/json?subscription-key={subscriptionKey}&api-version=1.0&query={searchTerm}&limit=10&countrySet={countrySetCsv}");

            //&typeahead ={ typeahead}
            //&limit ={ limit}
            //&ofs ={ ofs}
            //&countrySet ={ countrySet}
            //&lat ={ lat}
            //&lon ={ lon}
            //&radius ={ radius}
            //&topLeft ={ topLeft}
            //&btmRight ={ btmRight}
            //&language ={ language}
            //&extendedPostalCodesFor ={ extendedPostalCodesFor}

            var result = _restService.Get<AzureMapsSearchResponse>(uri);

            return result;
        }


        public AzureMapsReverseSearchResponse ReverseAddressSearch(decimal latitude, decimal longtitude)
        {
            var subscriptionKey = _azureDeploymentEnvironmentService.SubscriptionId;


            var uri = new Uri(
                _azureMapsServiceConfiguration.RootUri
                + $"/search/address/reverse/json?subscription-key={subscriptionKey}&api-version=1.0&query={latitude},{longtitude}");

            var result = _restService.Get<AzureMapsReverseSearchResponse>(uri);

            return result;
        }
    }
}