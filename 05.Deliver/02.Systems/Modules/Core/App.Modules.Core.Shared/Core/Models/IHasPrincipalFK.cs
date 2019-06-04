using System;

namespace App.Modules.Core.Models
{
    public interface IHasPrincipalFK
    {
        Guid PrincipalFK { get; set; }
    }
}