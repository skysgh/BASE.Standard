// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class SessionOperation : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasOwnerFK
    {
        // A Session Operation is bound to a Session
        // Which is bound to a Principal, but not a Tenant
        public virtual Guid? SessionFK { get; set; }

        /// <summary>
        ///     Gets or sets the client ip.
        ///     <para>
        ///         Note that you record the IP on the operation,
        ///         not the session, as IPs can switch multiple times
        ///         as mobile phones travel between cells.
        ///     </para>
        /// </summary>
        public virtual string ClientIp { get; set; }

        /// <summary>
        ///     Gets or sets the URL.
        /// </summary>
        public virtual string Url { get; set; }

        public virtual string ResourceTenantKey { get; set; }
        public virtual string ControllerName { get; set; }
        public virtual string ActionName { get; set; }
        public virtual string ActionArguments { get; set; }
        public virtual DateTimeOffset? BeginDateTimeUtc { get; set; }
        public virtual DateTimeOffset? EndDateTimeUtc { get; set; }

        /// <summary>
        ///     Gets or sets the duration between
        ///     Begin and End.
        /// </summary>
        /// <value>
        ///     The duration.
        /// </value>
        public virtual TimeSpan Duration { get; set; }

        /// <summary>
        ///     Gets or sets the HTTP response code (200 or else).
        /// </summary>
        /// <value>
        ///     The response code.
        /// </value>
        public virtual string ResponseCode { get; set; }


        /// <summary>
        ///     Returns the FK of the
        ///     parent, owning entity.
        /// </summary>
        /// <returns></returns>
        public Guid GetOwnerFk()
        {
            return SessionFK ?? new Guid();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}