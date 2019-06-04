using System;

namespace App.Modules.Core.Models
{
    public interface IHasDateTimedSignature
    {
        DateTimeOffset DateTimeUpdated { get; set; }
        string Signature { get; set; }
    }
}