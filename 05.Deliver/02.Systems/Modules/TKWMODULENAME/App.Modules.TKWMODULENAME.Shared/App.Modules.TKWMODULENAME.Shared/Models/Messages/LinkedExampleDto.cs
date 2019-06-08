using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages.API.V0100;

namespace App.Modules.TKWMODULENAME.Shared.Models.Messages
{


    public class LinkedExampleDto : IHasGuidId
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public NZDataClassification DataClassificationFK { get; set; }
        public DataClassificationDto DataClassification { get; set; }
    }
}
