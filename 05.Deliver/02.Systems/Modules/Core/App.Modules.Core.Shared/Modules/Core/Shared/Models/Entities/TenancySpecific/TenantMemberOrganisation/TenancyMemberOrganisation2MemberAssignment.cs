// Copyright MachineBrains, Inc.

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities.TenantMember.Profile;

namespace App.Modules.Core.Shared.Models.Entities.TenantMemberOrganisation
{
    public class TenancyMemberOrganisation2MemberAssignment : IHasEnabled, IHasEnabledBeginningUtc, IHasEndDateUtc
    {
        public bool Enabled { get; set; }

        public DateTime? EnabledBeginningUtc { get; set; }
        public DateTime? EnabledEndingUtc { get; set; }

        public DateTime? RoleAcceptedUtc { get; set; }

        public TenancyMemberOrganisationRole Role { get; set; }


        public Guid TenancyMemberOrganisationFK { get; set; }
        public TenancyMemberOrganisation TenancyMemberOrganisation { get; set; }

        public Guid TenantMemberFK { get; set; }
        public TenantMemberProfile TenantMember { get; set; }

    }
}