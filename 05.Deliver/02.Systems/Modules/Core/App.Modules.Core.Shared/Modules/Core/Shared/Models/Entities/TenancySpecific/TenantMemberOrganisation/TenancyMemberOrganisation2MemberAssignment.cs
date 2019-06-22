// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities.TenantMember.Profile;

namespace App.Modules.Core.Shared.Models.Entities.TenantMemberOrganisation
{
    /// <summary>
    ///     TODO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabled" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" />
    public class TenancyMemberOrganisation2MemberAssignment
        : IHasEnabled,
            IHasEnabledBeginningUtcDateTime,
            IHasEnabledEndUtcDateTime
    {
        /// <summary>
        ///     Gets or sets when the role was accepted.
        /// </summary>
        /// <value>
        ///     The role accepted UTC.
        /// </value>
        public virtual DateTimeOffset? RoleAcceptedUtc { get; set; }

        /// <summary>
        ///     Gets or sets the role being offered.
        /// </summary>
        public virtual TenancyMemberOrganisationRole Role { get; set; }


        /// <summary>
        ///     Gets or sets the FK of the organisation
        ///     the principal is being invited to.
        /// </summary>
        public virtual Guid TenancyMemberOrganisationFK { get; set; }

        /// <summary>
        ///     Gets or sets the organisation
        ///     the principal is being invited to.
        /// </summary>
        public virtual TenancyMemberOrganisation TenancyMemberOrganisation { get; set; }

        /// <summary>
        ///     Gets or sets the FK of the member being invited to the organisation.
        /// </summary>
        public virtual Guid TenantMemberFK { get; set; }

        /// <summary>
        ///     Gets or sets the member being invited to the organisation.
        /// </summary>
        public virtual TenantMemberProfile TenantMember { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        ///     <para>
        ///         See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        ///         and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" />
        ///     </para>
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets when the the record will be disabled.
        /// </summary>
        public virtual DateTimeOffset? EnabledBeginningUtcDateTime { get; set; }

        /// <summary>
        ///     Gets or sets the future UTC date time
        ///     when the object will be disabled.
        ///     <para>
        ///         <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" />
        ///     </para>
        /// </summary>
        public virtual DateTimeOffset? EnabledEndingUtcDateTime { get; set; }
    }
}