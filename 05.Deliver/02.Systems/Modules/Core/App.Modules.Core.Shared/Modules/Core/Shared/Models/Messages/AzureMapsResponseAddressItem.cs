// Copyright MachineBrains, Inc. 2019

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// A single item within the <see cref="AzureMapsReverseSearchResponse"/>
    /// </summary>
    [DataContract]
    public class AzureMapsResponseAddressItem
    {
        /// <summary>
        /// Gets or sets the address for this item.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [JsonProperty("address")] public AzureMapsResponseAddress Address { get; set; }
        /// <summary>
        /// Gets or sets the lat/long.
        /// </summary>
        [JsonProperty("position")] public string Position { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}