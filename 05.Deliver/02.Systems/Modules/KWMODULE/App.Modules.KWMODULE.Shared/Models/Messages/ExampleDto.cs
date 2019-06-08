using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.KWMODULE.Shared.Models.Messages
{
    public class ExampleDto : IHasGuidId
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

    }
}
