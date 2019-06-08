using System.Collections.Generic;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    public class AzureMapsReverseSearchResponse
    {
        [JsonProperty("addresses")]
        public List<AzureMapsResponseAddress> Addresses
        {
            get { return _addresses ?? (_addresses = new List<AzureMapsResponseAddress>()); }
        }
        List<AzureMapsResponseAddress> _addresses;
    }
}