using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    public class AzureMapResponsePosition
    {
        [JsonProperty("lat")]
        public string Latitude { get; set; }
        [JsonProperty("lon")]
        public string Longitude { get; set; }
    }
}