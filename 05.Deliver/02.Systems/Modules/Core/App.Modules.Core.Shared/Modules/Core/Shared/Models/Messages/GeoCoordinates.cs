// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     Entity to record coordinates on a map.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasLatitudeAndLongitude" />
    public class GeoCoordinates : IHasLatitudeAndLongitude
    {
        /// <summary>
        ///     Gets or sets the latitude of the coordinate.
        /// </summary>
        /// <value>
        ///     The latitude.
        /// </value>
        public decimal Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude of the coordinate.
        /// </summary>
        /// <value>
        ///     The longitude.
        /// </value>
        public decimal Longitude { get; set; }
    }
}