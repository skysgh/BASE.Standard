namespace App.Modules.Core.Shared.Models
{
    using System;

    public interface IHasPrincipalFK
    {
        Guid PrincipalFK { get; set; }
    }
}