// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public class SessionOperationDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : IHasGuidId
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public virtual string ClientIp { get; set; }
        public virtual string Url { get; set; }
        public virtual string ResourceTenantKey { get; set; }
        public virtual string ControllerName { get; set; }
        public virtual string ActionName { get; set; }
        public virtual string ActionArguments { get; set; }
        public virtual DateTimeOffset? BeginDateTimeUtc { get; set; }
        public virtual DateTimeOffset? EndDateTimeUtc { get; set; }
        public virtual TimeSpan Duration { get; set; }
        public virtual string ResponseCode { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}