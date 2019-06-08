using System;

namespace App.Modules.All.Shared.Models
{
    public interface IHasPrincipalFK
    {
        Guid PrincipalFK { get; set; }
    }
}