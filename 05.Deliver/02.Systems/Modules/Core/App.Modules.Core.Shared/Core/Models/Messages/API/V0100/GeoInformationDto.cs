namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class GeoInformationDto
    {
        public GeoInformationCountryRegionDto CountryRegion { get; set; }

        public string IPAddress { get; set; }
    }

    public class GeoInformationCountryRegionDto
    {
        public string IsoCode { get; set; }
    }
}
