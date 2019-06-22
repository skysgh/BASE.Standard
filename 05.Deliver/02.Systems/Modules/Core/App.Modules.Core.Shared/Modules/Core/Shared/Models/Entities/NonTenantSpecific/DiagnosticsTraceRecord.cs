// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A trace record.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDateTimeCreatedUtc" />
    public class DiagnosticsTraceRecord :
        IHasGuidId,
        //IHasTimestamp,
        IHasDateTimeCreatedUtc
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DiagnosticsTraceRecord" /> class.
        /// </summary>
        public DiagnosticsTraceRecord()
        {
            Id = GuidFactory.NewGuid();
        }

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
        ///     Gets or sets the UTC date time when the record was created.
        /// </summary>
        public DateTimeOffset UtcDateTimeCreated { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}