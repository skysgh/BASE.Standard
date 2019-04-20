namespace App.Modules.Core.Shared.Models.Entities
{
    using App.Modules.Core.Shared.Models;
    using App.Modules.Core.Shared.Models.Entities;

    public class TenancySecurityProfilePermission : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasTitleAndDescription
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

}

