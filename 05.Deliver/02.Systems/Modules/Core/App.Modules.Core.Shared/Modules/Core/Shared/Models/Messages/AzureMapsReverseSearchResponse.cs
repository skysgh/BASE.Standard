using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// Response object
    /// for a specific use of
    /// Azure Maps.
    /// </summary>
    public class AzureMapsReverseSearchResponse
    {
        /// <summary>
        /// Gets the addresses.
        /// </summary>
        /// <value>
        /// The addresses.
        /// </value>
        [JsonProperty("addresses")]
        public List<AzureMapsResponseAddress> Addresses
        {
            get { return _addresses ?? (_addresses = new List<AzureMapsResponseAddress>()); }
        }
        List<AzureMapsResponseAddress> _addresses;
    }
}