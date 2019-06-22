// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="EnabledEndingUtcDateTime" />
    ///     property.
    /// </summary>
    public interface IHasEnabledEndUtcDateTime
    {
        /// <summary>
        ///     Gets or sets the future UTC date time
        ///     when the object will be disabled.
        ///     <para>
        ///         <see cref="IHasEnabled" />
        ///     </para>
        /// </summary>
        DateTimeOffset? EnabledEndingUtcDateTime { get; set; }
    }
}