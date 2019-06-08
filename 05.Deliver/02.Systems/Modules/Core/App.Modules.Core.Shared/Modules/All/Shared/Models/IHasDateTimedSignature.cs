using System;

namespace App.Modules.All.Shared.Models
{
    public interface IHasDateTimedSignature
    {
        DateTimeOffset DateTimeUpdated { get; set; }
        string Signature { get; set; }
    }
}