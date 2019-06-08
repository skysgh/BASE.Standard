using System;

namespace App.Modules.All.Shared.Models
{
    public interface IHasOwnerFK
    {
        Guid GetOwnerFk();
    }
}