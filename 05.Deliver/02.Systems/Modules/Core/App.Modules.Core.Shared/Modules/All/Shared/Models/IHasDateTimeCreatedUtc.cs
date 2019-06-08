using System;

namespace App.Modules.All.Shared.Models
{
    public interface IHasDateTimeCreatedUtc
    {
        DateTime DateTimeCreatedUtc { get; set; }
    }
}