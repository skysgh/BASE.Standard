// Copyright MachineBrains, Inc. 2019

using System.Runtime.Serialization;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     A model of geo coordinates.
    ///     <para>
    ///         Used as a Query object by the IGeoLocationService. Or part of the Response.
    ///     </para>
    /// </summary>
    [DataContract]
    public class GeoInformation
    {

        /// <summary>
        ///     Gets or sets the ip address.
        /// </summary>
        /// <value>
        ///     The ip address.
        /// </value>
        [DataMember(Name = "ip")]
        public string IP { get; set; }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        [DataMember(Name = "continent_code")]
        public string ContinentCode { get; set; }
        [DataMember(Name = "continent_name")]
        public string ContinentName { get; set; }
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }
        [DataMember(Name = "country_name")]
        public string CountryName { get; set; }
        [DataMember(Name = "region_code")]
        public string RegionCode { get; set; }
        [DataMember(Name = "region_name")]
        public string RegionName { get; set; }
        public string City { get; set; }
        [DataMember(Name = "zip")]
        public string Zip { get; set; }
        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}