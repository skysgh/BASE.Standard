namespace App.Modules.Core.Shared.Models
{
    using System;

    public interface IHasOwnerFK
    {
        Guid GetOwnerFk();
    }
}