using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    public class AzureMapsSearchResponseResult
    {
        [JsonProperty("results")]
        string Type { get; set; }
        [JsonProperty("score")]
        string Score { get; set; }
        [JsonProperty("address")]
        public AzureMapsResponseAddress Address { get; set; }
        [JsonProperty("position")]
        public AzureMapResponsePosition Position { get; set; }
    }
}