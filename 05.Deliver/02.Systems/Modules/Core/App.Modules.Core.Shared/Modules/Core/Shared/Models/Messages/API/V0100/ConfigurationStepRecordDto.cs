// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO for <see cref="ConfigurationStepRecord" />
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class ConfigurationStepRecordDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        /// <summary>
        ///     Gets or sets the date time.
        /// </summary>
        public virtual DateTimeOffset? DateTime { get; set; }

        /// <summary>
        ///     Gets or sets the configuration type.
        /// </summary>
        public virtual ConfigurationStepType Type { get; set; }

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }
    }
}