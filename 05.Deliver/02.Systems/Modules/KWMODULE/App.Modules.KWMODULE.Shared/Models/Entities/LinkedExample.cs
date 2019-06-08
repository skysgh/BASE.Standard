using System;
using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.KWMODULE.Shared.Models.Entities
{
    public class LinkedExample : UntenantedRecordStatedTimestampedGuidIdEntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public NZDataClassification DataClassificationFK { get; set; }
        public DataClassification DataClassification { get; set; }
    }
}
