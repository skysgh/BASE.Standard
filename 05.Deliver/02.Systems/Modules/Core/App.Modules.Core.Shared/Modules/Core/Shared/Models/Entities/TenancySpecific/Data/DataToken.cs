using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A data token ensures the data is *not*
    ///     in the actual table, so if it is ever
    ///     inadvertently leaked, the data is basically
    ///     useless.
    /// </summary>
    public class DataToken 
        : TenantFKRecordStatedTimestampedGuidIdEntityBase,
            IHasValue<string>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public virtual string Value { get; set; }
    }
}