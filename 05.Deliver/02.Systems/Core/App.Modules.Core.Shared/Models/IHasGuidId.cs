using System;
using System.Collections.Generic;
using System.Text;

namespace App.Modules.Core.Shared.Models
{
    public interface IHasGuidId
    {
        Guid Id { get; set; }
    }
}
