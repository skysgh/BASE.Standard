using App.Modules.Core.Models;
using App.Modules.Core.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.Enums;

namespace App.Modules.Design.Shared.Models.Entities.NonTenantSpecific
{
    public class Requirement : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasISO25010, IHasTitleAndDescription
    {
        public ISO25010 ISO25010Quality { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
