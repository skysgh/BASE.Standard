namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// A model of geo coordinates.
    /// <para>
    /// Used as a Query object by the IGeoLocationService. Or part of the Response.
    /// </para>
    /// </summary>
    public class GeoInformation
    {
        /// <summary>
        /// Gets or sets the country region.
        /// </summary>
        /// <value>
        /// The country region.
        /// </value>
        public GeoInformationCountryRegion CountryRegion { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public string IPAddress { get; set; }
    }

}
