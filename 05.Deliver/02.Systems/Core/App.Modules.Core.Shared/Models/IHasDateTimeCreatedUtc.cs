namespace App.Modules.Core.Shared.Models
{
    using System;

    public interface IHasDateTimeCreatedUtc
    {
        DateTime DateTimeCreatedUtc { get; set; }
    }
}