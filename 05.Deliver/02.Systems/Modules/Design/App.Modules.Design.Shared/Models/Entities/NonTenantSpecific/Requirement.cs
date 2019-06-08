using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Design.Shared.Models.Entities.Enums;

namespace App.Modules.Design.Shared.Models.Entities.NonTenantSpecific
{
    public class Requirement : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasISO25010, IHasTitleAndDescription
    {
        public ISO25010 ISO25010Quality { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
