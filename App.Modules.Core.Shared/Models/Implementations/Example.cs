using App.Modules.Core.Shared.Models;
using System;

namespace App.Core.Shared.Models.Implementations
{
    public class Example : IHasGuidId
    {
        public Example()
        {
        }

        public Guid Id { get; set; }

    }
}
