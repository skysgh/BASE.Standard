namespace App.Modules.Core.Models.Entities
{

    /// <summary>
    /// A Tenancy-specific record of Geodata.
    /// </summary>
    public class GeoData : TenantFKRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription, IHasLatitudeAndLongitude, IHasValue<decimal?>
    {
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }

        public virtual decimal Latitude { get; set; }
        public virtual decimal Longitude { get; set; }

        public virtual GeoDataType Type { get; set; }
        public virtual decimal? Value { get; set; }
        public virtual string Color { get; set; }
        public virtual bool Draggable { get; set; }
    }
}