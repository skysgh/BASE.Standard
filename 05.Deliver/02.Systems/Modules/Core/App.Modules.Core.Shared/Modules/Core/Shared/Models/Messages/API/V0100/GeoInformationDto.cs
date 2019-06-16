namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// DTO for <see cref="GeoInformation"/>
    /// </summary>
    public class GeoInformationDto
    {
        /// <summary>
        /// Gets or sets the country region.
        /// </summary>
        /// <value>
        /// The country region.
        /// </value>
        public GeoInformationCountryRegionDto CountryRegion { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public string IPAddress { get; set; }
    }
}
