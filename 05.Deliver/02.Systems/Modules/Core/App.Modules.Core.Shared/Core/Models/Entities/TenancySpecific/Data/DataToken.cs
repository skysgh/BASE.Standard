namespace App.Modules.Core.Models.Entities
{
    /// <summary>
    ///     A data token ensures the data is *not*
    ///     in the actual table, so if it is ever
    ///     inadvertently leaked, the data is basically
    ///     useless.
    /// </summary>
    public class DataToken : TenantFKRecordStatedTimestampedGuidIdEntityBase
    {
        public virtual string Value { get; set; }
    }
}