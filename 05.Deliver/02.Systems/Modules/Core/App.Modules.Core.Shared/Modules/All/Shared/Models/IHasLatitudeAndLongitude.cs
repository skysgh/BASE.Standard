namespace App.Modules.All.Shared.Models
{
    public interface IHasLatitudeAndLongitude
    {
        decimal Latitude { get; set; }
        decimal Longitude { get; set; }
    }
}