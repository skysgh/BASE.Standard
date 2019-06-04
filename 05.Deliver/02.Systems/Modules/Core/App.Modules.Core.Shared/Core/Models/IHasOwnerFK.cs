using System;

namespace App.Modules.Core.Models
{
    public interface IHasOwnerFK
    {
        Guid GetOwnerFk();
    }
}