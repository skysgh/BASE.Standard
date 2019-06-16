namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="Latitude"/>
    /// and
    /// <see cref="Longitude"/>
    /// property.
    /// </summary>
    public interface IHasLatitudeAndLongitude
    {
        /// <summary>
        /// Gets or sets the latitude of the coordinate.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        decimal Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the coordinate.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        decimal Longitude { get; set; }
    }
}