using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.TKWMODULENAME.Shared.Models.Messages
{

    public class TenantedExampleDto : IHasGuidId
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

    }
}
