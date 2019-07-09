// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     Response object
    ///     from a reverse search
    ///     done using Azure Maps service.
    /// </summary>
    [DataContract]
    public class AzureMapsReverseSearchResponse
    {
        private List<AzureMapsResponseAddressItem> _addresses;

        /// <summary>
        ///     Gets a list of nearest addresses.
        /// </summary>
        [JsonProperty("addresses")]
        public List<AzureMapsResponseAddressItem> Addresses
        {
            get
            {
                return _addresses ?? (_addresses = new List<AzureMapsResponseAddressItem>());
            }
            set { _addresses = value; }
        }
    }
}