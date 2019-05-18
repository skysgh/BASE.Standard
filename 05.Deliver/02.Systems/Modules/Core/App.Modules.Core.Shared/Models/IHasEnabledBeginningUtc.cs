// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Shared.Models
{
    public interface IHasEnabledBeginningUtc
    {
        DateTime? EnabledBeginningUtc { get; set; }
    }
}