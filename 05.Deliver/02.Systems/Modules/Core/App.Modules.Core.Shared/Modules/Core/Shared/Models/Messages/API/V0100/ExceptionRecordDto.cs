using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// Creates a DTO of the <see cref="ExceptionRecord"/>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class ExceptionRecordDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ :
        IHasGuidId
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        //TODO: Convert to DateTimeOffset?

        /// <summary>
        /// Gets or sets the UTC the record was created on.
        /// </summary>
        /// <value>
        /// The created on UTC.
        /// </value>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public TraceLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the thread identifier.
        /// </summary>
        public string ThreadId { get; set; }

        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the stack.
        /// </summary>
        public string Stack { get; set; }
    }
}