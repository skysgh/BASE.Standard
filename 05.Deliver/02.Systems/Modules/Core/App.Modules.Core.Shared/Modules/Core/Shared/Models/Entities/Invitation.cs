// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Entities.TenantMemberOrganisation;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     An invitation to a member.
    /// </summary>
    public class Invitation
        : UntenantedRecordStatedTimestampedGuidIdEntityBase,
            IHasEnabledBeginningUtcDateTime,
            IHasEnabledEndUtcDateTime
    {
        /// <summary>
        ///     Gets or sets the state of the invitation.
        /// </summary>
        public TenancyMemberOrganisationInvitationState State { get; set; }

        /// <summary>
        ///     <para>
        ///         A User may not yet be a member of an Organisation or even a Tenancy.
        ///         So you can't refer to an FK.
        ///         But email addresses are problematic to search on (case sensitivity, including the user name in quotations,
        ///         etc.)
        ///     </para>
        /// </summary>
        public string PrincipalEmail { get; set; }


        /// <summary>
        ///     The organisation the Principal is being invited to.
        /// </summary>
        public Guid TenancyMemberOrganisationFK { get; set; }


        /// <summary>
        ///     The role in which the Member is being invited as:
        /// </summary>
        public TenancyMemberOrganisationRole Role { get; set; }

        /// <summary>
        ///     Date the invitation was sent out.
        /// </summary>
        public DateTimeOffset? EnabledBeginningUtcDateTime { get; set; }


        /// <summary>
        ///     Date the invitation expires.
        /// </summary>
        public DateTimeOffset? EnabledEndingUtcDateTime { get; set; }
    }
}