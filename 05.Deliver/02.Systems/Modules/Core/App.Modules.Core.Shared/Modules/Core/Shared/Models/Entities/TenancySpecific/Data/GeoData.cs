// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A Tenancy-specific record of Geodata.
    /// </summary>
    public class GeoData :
        TenantFKRecordStatedTimestampedGuidIdEntityBase,
        IHasTitleAndDescription,
        IHasLatitudeAndLongitude,
        IHasValue<decimal?>
    {
        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public virtual GeoDataType Type { get; set; }

        /// <summary>
        ///     Gets or sets the color.
        /// </summary>
        /// <value>
        ///     The color.
        /// </value>
        public virtual string Color { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="GeoData" /> is draggable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if draggable; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Draggable { get; set; }

        /// <summary>
        ///     Gets or sets the latitude of the coordinate.
        /// </summary>
        /// <value>
        ///     The latitude.
        /// </value>
        public virtual decimal Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude of the coordinate.
        /// </summary>
        /// <value>
        ///     The longitude.
        /// </value>
        public virtual decimal Longitude { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        public virtual decimal? Value { get; set; }
    }
}