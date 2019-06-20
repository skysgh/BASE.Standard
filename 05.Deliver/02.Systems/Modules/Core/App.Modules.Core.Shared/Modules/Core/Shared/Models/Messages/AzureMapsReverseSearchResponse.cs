using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// Response object
    /// from a reverse search
    /// done using Azure Maps service.
    /// </summary>
    public class AzureMapsReverseSearchResponse
    {
        /// <summary>
        /// Gets a list of nearest addresses.
        /// </summary>
        [JsonProperty("addresses")]
        public List<AzureMapsResponseAddress> Addresses
        {
            get { return _addresses ?? (_addresses = new List<AzureMapsResponseAddress>()); }
        }
        List<AzureMapsResponseAddress> _addresses;
    }
}