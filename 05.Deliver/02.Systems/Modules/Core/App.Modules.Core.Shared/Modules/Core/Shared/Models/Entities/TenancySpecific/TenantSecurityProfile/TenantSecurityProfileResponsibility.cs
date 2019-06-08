using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// A <see cref="TenantSecurityProfile"/>
    /// has both a set of <see cref="TenantSecurityProfilePermission"/>s
    /// as well as a set of <see cref="TenantSecurityProfileResponsibility"/>s.
    /// </summary>
    public class TenantSecurityProfileResponsibility : TenantFKRecordStatedTimestampedGuidIdEntityBase,
        IHasTitleAndDescription
    {
        public TenantSecurityProfileResponsibility()
        {
            Enabled = true;
        }

        public bool Enabled { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

}
