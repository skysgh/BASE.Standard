using System;

namespace App.Modules.Core.Models
{
    public interface IHasDateTimeCreatedUtc
    {
        DateTime DateTimeCreatedUtc { get; set; }
    }
}