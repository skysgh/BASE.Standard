// Copyright MachineBrains, Inc. 2019

using System;
using System.Linq;
using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Infrastructure.Services.Configuration;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations.AzureServices
{
    public class AzureMapsService
        : AppCoreServiceBase
            , IAzureMapsService
            , IHasPing
    {
        private readonly AzureMapsServiceConfiguration _configuration;
        private readonly IConfigurationStatusService _configurationStatusService;
        private readonly IRestService _restService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMapsService" /> class.
        /// </summary>
        /// <param name="azuresMapServiceConfiguration">The azures map service configuration.</param>
        /// <param name="configurationStatusService">The configuration status service.</param>
        /// <param name="restService">The rest service.</param>
        public AzureMapsService(
            AzureMapsServiceConfiguration azuresMapServiceConfiguration,
            IConfigurationStatusService configurationStatusService,
            IRestService restService)
        {
            _configuration = azuresMapServiceConfiguration;
            this._configurationStatusService = configurationStatusService;
            _restService = restService;
        }

        /// <summary>
        ///     Find the most appropriate address, given the search term.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <param name="countrySetCsv">The country set CSV.</param>
        /// <param name="typeAhead">if set to <c>true</c> [type ahead].</param>
        /// <returns></returns>
        public AzureMapsSearchResponse AddressSearch(string searchTerm,
            string countrySetCsv, bool typeAhead = true)
        {

            if (!_configuration.Enabled)
            {
                return new AzureMapsSearchResponse();
            }

            var subscriptionKey = _configuration.ClientSecret;

            var uri = new Uri(
                _configuration.BaseUri
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

            try
            {
                var result = _restService.Get<AzureMapsSearchResponse>(uri);
                _configurationStatusService.SetStatusToVerified<IAzureMapsService>();

                return result;
            }
#pragma warning disable IDE0059 // Value assigned to symbol is never used
#pragma warning disable CS0168 // Variable is declared but never used
            catch (System.Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
#pragma warning restore IDE0059 // Value assigned to symbol is never used
            {
                throw;
            }

        }


        /// <summary>
        ///     Find a list of
        ///     <see cref="AzureMapsResponseAddress" />
        ///     nearest the supplied lat/long.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        public AzureMapsReverseSearchResponse ReverseAddressSearch(
            decimal latitude,
            decimal longitude)
        {
            if (!_configuration.Enabled)
            {
                return new AzureMapsReverseSearchResponse();
            }

            var subscriptionKey = _configuration.ClientSecret;


            var uri = new Uri(
                _configuration.BaseUri
                + $"/search/address/reverse/json?subscription-key={subscriptionKey}&api-version=1.0&query={latitude},{longitude}");

            try
            {
                var result =
                    _restService.Get<AzureMapsReverseSearchResponse>(uri);

                _configurationStatusService.SetStatusToVerified<IAzureMapsService>();
                return result;
            }
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable IDE0059 // Value assigned to symbol is never used
            catch (SystemException e)
#pragma warning restore IDE0059 // Value assigned to symbol is never used
#pragma warning restore CS0168 // Variable is declared but never used
            {
                throw;
            }

        }


        public bool Ping()
        {
            if (!_configuration.Enabled)
            {
                return false;
            }

            try
            {
                var result =
                    this.ReverseAddressSearch((decimal)-41.2865,
                        (decimal)174.7762);

                if (result.Addresses.First().Address.Country == "NZ")
                {
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
    }
}