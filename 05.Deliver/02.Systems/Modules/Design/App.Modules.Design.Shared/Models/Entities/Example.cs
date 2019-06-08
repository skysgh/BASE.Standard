using System;
using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Design.Shared.Models.Entities
{
    public class Example : UntenantedRecordStatedTimestampedGuidIdEntityBase
    {
        public NZDataClassification DataClassificationFK { get; set; }
        public DataClassification DataClassification { get; set; }
    }
}
