// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     DTO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class DiagnosticsTraceRecordDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        :
            IHasGuidId
    {
        /// <summary>
        ///     Gets or sets the date time created UTC.
        /// </summary>
        /// <value>
        ///     The date time created UTC.
        /// </value>
        public DateTimeOffset DateTimeCreatedUtc { get; set; }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        /// <value>
        ///     The level.
        /// </value>
        public TraceLevel Level { get; set; }

        /// <summary>
        ///     Gets or sets the thread identifier.
        /// </summary>
        /// <value>
        ///     The thread identifier.
        /// </value>
        public string ThreadId { get; set; }

        /// <summary>
        ///     Gets or sets the client identifier.
        /// </summary>
        /// <value>
        ///     The client identifier.
        /// </value>
        public string ClientId { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}