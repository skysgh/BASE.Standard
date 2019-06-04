using System;
using System.Collections.Generic;
using App.Modules.Core.Factories;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class SecurityProfileDto : IHasGuidId
    {
        public SecurityProfileDto()
        {
            GuidFactory.NewGuid();
        }

        public Guid Id { get; set; }

        public string Key { get; set; }

        public ICollection<SecurityProfileRoleGroupDto> AccountGroups { get; set; }

        public ICollection<SecurityProfileRoleDto> Roles { get; set; }

        public ICollection<SecurityProfileSecurityProfilePermissionAssignmentDto> PermissionsAssignments { get; set; }
    }
}
