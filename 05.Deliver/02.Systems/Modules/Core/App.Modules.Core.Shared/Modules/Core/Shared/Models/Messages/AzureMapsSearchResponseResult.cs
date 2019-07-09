// Copyright MachineBrains, Inc. 2019

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    [DataContract]
    public class AzureMapsSearchResponseResult
    {
        [JsonProperty("results")] private string Type { get; set; }

        [JsonProperty("score")] private string Score { get; set; }

        [JsonProperty("address")] public AzureMapsResponseAddress Address { get; set; }

        [JsonProperty("position")] public AzureMapResponsePosition Position { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}