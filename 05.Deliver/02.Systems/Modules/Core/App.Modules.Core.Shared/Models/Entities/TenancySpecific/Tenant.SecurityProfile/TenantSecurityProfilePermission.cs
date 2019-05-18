namespace App.Modules.Core.Shared.Models.Entities.TenancySpecific
{
    using App.Modules.Core.Shared.Models;
    using App.Modules.Core.Shared.Models.Entities;

    /// <summary>
    /// A tenant-specific Role that can be part of a <see cref="TenantSecurityProfileRole"/>
    /// or assigned directly to a <see cref="TenantSecurityProfile"/>
    /// </summary>
    public class TenantSecurityProfilePermission : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {
        public TenantSecurityProfilePermission()
        {
            Enabled = true;
        }

        public bool Enabled { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }

}

