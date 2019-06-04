// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Models
{
    public interface IHasEnabledBeginningUtc
    {
        DateTime? EnabledBeginningUtc { get; set; }
    }
}