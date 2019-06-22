// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO for updating the status of Notifications.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class NotificationUpdateDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        /// <summary>
        ///     Status whether Message has been read.
        /// </summary>
        public virtual bool Read { get; set; }


        /// <summary>
        ///     The time the client read the message (if offline, will be different than time server records it).
        /// </summary>
        public virtual DateTimeOffset DateTimeModifiedUtc { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }
    }
}