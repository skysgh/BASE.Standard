using Newtonsoft.Json;

namespace App.Modules.Core.Shared.Models.Messages
{
    public class AzureMapsResponseAddress
    {
        [JsonProperty("buildingNumber")]
        public string BuildingNumber { get; set; }
        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("streetName")]
        public string StreetName { get; set; }
        [JsonProperty("streetNameAndNumber")]
        public string StreetNameAndNumber { get; set; }
        [JsonProperty("municipalitySubDivision")]
        public string MunicipalitySubDivision { get; set; }
        [JsonProperty("municipality")]
        public string Municipality { get; set; }
        [JsonProperty("countrySecondarySubdivision")]
        public string CountrySecondarySubdivision { get; set; }
        [JsonProperty("countrySubdivision")]
        public string CountrySubdivision { get; set; }
        [JsonProperty("countryCodeISO3")]
        public string CountryCodeISO3 { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("extendedPostalCode")]
        public string PostalCodeExtended { get; set; }

        [JsonProperty("freeformAddress")]
        public string FreeFormAddress { get; set; }

        public string ExtendedFreeFormAddress
        {
            get
            {
                return this.FreeFormAddress + ", " + this.Country;
            }
        }

        [JsonProperty("routeNumbers")]
        public string[] RouteNumbers { get; set; }
    }
}