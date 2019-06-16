using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{

    /// <summary>
    /// 
    /// </summary>
    public class AzureMapsSearchResponse
    {
        [JsonProperty("results")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public AzureMapsSearchResponseResult[] Results { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}

