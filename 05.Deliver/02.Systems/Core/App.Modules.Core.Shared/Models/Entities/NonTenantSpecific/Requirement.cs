using App.Modules.Core.Shared.Models.Messages.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Shared.Models.Entities.NonTenantSpecific
{
    public class Requirement : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase , IHasISO25010, IHasTitleAndDescription
    {
        public ISO25010 ISO25010Quality { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
