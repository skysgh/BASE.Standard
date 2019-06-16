// Copyright MachineBrains, Inc.

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="EnabledBeginningUtcDateTime"/>
    /// property.
    /// </summary>
    public interface IHasEnabledBeginningUtcDateTime
    {
        /// <summary>
        /// Gets or sets when the the record will be disabled.
        /// </summary>
        DateTimeOffset? EnabledBeginningUtcDateTime { get; set; }
    }
}