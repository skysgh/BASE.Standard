using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    public class Account : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled
    {
        public bool Enabled { get; set; }
    }

}
