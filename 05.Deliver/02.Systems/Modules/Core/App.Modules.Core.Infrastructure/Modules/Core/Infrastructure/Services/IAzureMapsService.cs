// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.All.Shared.Attributes;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    /// <summary>
    ///     Contract for a service to manage requests
    ///     to Azure Maps.
    /// </summary>
    /// <seealso cref="App.Modules.All.Infrastructure.Services.IInfrastructureService" />
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IAzureService" />
    [TitleDescription("Azure Maps Service",
        "A service to convert Coordinates to Addresses, and vice versa.")]
    public interface IAzureMapsService : IRemoteServiceClientInfrastructureService, IAzureService
    {
        /// <summary>
        ///     Find the most appropriate address, given the search term.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <param name="countrySetCsv">The country set CSV.</param>
        /// <param name="typeAhead">if set to <c>true</c> [type ahead].</param>
        /// <returns></returns>
        AzureMapsSearchResponse AddressSearch(
            string searchTerm,
            string countrySetCsv,
            bool typeAhead = true);


        /// <summary>
        ///     Find a list of
        ///     <see cref="AzureMapsResponseAddress" />
        ///     nearest the supplied lat/long.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns></returns>
        AzureMapsReverseSearchResponse ReverseAddressSearch(decimal latitude, decimal longitude);
    }
}