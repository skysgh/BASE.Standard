// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     Response object
    ///     from a reverse search
    ///     done using Azure Maps service.
    /// </summary>
    public class AzureMapsReverseSearchResponse
    {
        private List<AzureMapsResponseAddress> _addresses;

        /// <summary>
        ///     Gets a list of nearest addresses.
        /// </summary>
        [JsonProperty("addresses")]
        public List<AzureMapsResponseAddress> Addresses =>
            _addresses ?? (_addresses = new List<AzureMapsResponseAddress>());
    }
}