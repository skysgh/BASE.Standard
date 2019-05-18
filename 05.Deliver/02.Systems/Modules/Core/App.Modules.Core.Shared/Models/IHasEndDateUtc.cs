// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Shared.Models
{
    public interface IHasEndDateUtc 
    {
        DateTime? EnabledEndingUtc { get; set; }
    }
}