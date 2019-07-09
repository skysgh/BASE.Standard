// Copyright MachineBrains, Inc. 2019

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    /// <summary>
    /// A single address within a reverse search
    /// </summary>
    [DataContract]
    public class AzureMapsResponseAddress
    {
        /// <summary>
        /// Gets or sets the building number.
        /// </summary>
        /// <value>
        /// The building number.
        /// </value>
        [JsonProperty("buildingNumber")] public string BuildingNumber { get; set; }

        /// <summary>
        /// Gets or sets the street number.
        /// </summary>
        /// <value>
        /// The street number.
        /// </value>
        [JsonProperty("streetNumber")] public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [JsonProperty("street")] public string Street { get; set; }

        /// <summary>
        /// Gets or sets the name of the street.
        /// </summary>
        /// <value>
        /// The name of the street.
        /// </value>
        [JsonProperty("streetName")] public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the street name and number.
        /// </summary>
        /// <value>
        /// The street name and number.
        /// </value>
        [JsonProperty("streetNameAndNumber")] public string StreetNameAndNumber { get; set; }

        /// <summary>
        /// Gets or sets the municipality.
        /// </summary>
        /// <value>
        /// The municipality.
        /// </value>
        [JsonProperty("municipality")] public string Municipality { get; set; }

        /// <summary>
        /// Gets or sets the country subdivision.
        /// </summary>
        /// <value>
        /// The country subdivision.
        /// </value>
        [JsonProperty("countrySubdivision")] public string CountrySubdivision { get; set; }

        /// <summary>
        /// Gets or sets the name of the country subdivision.
        /// </summary>
        /// <value>
        /// The name of the country subdivision.
        /// </value>
        [JsonProperty("countrySubdivisionName")] public string CountrySubdivisionName { get; set; }
        /// <summary>
        /// Gets or sets the country code is o3.
        /// </summary>
        /// <value>
        /// The country code is o3.
        /// </value>
        [JsonProperty("countryCodeISO3")] public string CountryCodeISO3 { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        /// <value>
        /// The country code.
        /// </value>
        [JsonProperty("countryCode")] public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [JsonProperty("country")] public string Country { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [JsonProperty("postalCode")] public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the postal code extended.
        /// </summary>
        /// <value>
        /// The postal code extended.
        /// </value>
        [JsonProperty("extendedPostalCode")] public string PostalCodeExtended { get; set; }

        /// <summary>
        /// Gets or sets the free form address.
        /// </summary>
        /// <value>
        /// The free form address.
        /// </value>
        [JsonProperty("freeformAddress")] public string FreeFormAddress { get; set; }

        /// <summary>
        /// Gets the extended free form address.
        /// </summary>
        /// <value>
        /// The extended free form address.
        /// </value>
        public string ExtendedFreeFormAddress => FreeFormAddress + ", " + Country;

        /// <summary>
        /// Gets or sets the route numbers.
        /// </summary>
        /// <value>
        /// The route numbers.
        /// </value>
        [JsonProperty("routeNumbers")] public string[] RouteNumbers { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}