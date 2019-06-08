﻿using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    public class NotificationUpdateDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Status whether Message has been read.
        /// </summary>
        public virtual bool Read { get; set; }


        /// <summary>
        /// The time the client read the message (if offline, will be different than time server records it).
        /// </summary>
        public virtual DateTime DateTimeModifiedUtc { get; set; }

    }
}
