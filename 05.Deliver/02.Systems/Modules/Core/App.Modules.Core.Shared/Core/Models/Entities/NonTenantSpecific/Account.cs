namespace App.Modules.Core.Models.Entities
{
    public class Account : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled
    {
        public bool Enabled { get; set; }
    }

}
