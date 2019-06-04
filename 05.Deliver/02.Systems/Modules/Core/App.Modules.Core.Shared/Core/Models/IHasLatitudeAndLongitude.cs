namespace App.Modules.Core.Models
{
    public interface IHasLatitudeAndLongitude
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
}