using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{

    public class AzureMapsSearchResponse
    {
        [JsonProperty("results")]
        public AzureMapsSearchResponseResult[] Results { get; set; }
    }
}

