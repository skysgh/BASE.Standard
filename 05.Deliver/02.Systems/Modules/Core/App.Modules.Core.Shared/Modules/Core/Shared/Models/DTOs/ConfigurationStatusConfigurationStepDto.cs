// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO for <see cref="ConfigurationStatusComponentStep" />
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class ConfigurationStatusStepDto 
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ 
        : IHasGuidId
    {
        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }
        /// <summary>
        ///     Gets or sets the date time.
        /// </summary>
        public virtual DateTimeOffset? DateTime { get; set; }

        /// <summary>
        ///     Gets or sets the configuration type.
        /// </summary>
        public virtual ConfigurationStatusComponentStepType Type { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        public virtual string Task { get; set; }

        /// <summary>
        /// Gets or sets the outcome.
        /// </summary>
        /// <value>
        /// The outcome.
        /// </value>
        public virtual string Outcome { get; set; }

    }
}