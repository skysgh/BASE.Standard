// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.Core.Models
{
    public interface IHasEndDateUtc 
    {
        DateTime? EnabledEndingUtc { get; set; }
    }
}