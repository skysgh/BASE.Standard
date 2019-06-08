// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.All.Shared.Models
{
    public interface IHasEndDateUtc 
    {
        DateTime? EnabledEndingUtc { get; set; }
    }
}