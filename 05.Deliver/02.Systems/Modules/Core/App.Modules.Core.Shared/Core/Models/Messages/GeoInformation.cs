namespace App.Modules.Core.Models.Messages
{
    /// <summary>
    /// A model of geo coordinates.
    /// <para>
    /// Used as a Query object by the IGeoLocationService. Or part of the Response.
    /// </para>
    /// </summary>
    public class GeoInformation
    {
        public GeoInformationCountryRegion CountryRegion { get; set; }

        public string IPAddress { get; set; }
    }

}
