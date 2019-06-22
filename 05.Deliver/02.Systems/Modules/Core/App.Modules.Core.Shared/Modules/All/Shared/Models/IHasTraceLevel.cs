// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for messages and entities that define a trace level (eg: Notifications)
    /// </summary>
    public interface IHasTraceLevel
    {
        /// <summary>
        ///     Gets or sets the level of the message.
        /// </summary>
        TraceLevel Level { get; set; }
    }
}