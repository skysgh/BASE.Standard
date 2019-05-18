using App.Modules.Core.Shared.Models;
using System;

namespace App.Modules.Core.Shared.Models.Implementations
{
    public class ExampleModel : IHasGuidId
    {
        public ExampleModel()
        {
            //throw new Exception();
        }

        public Guid Id { get; set; }

    }
}
