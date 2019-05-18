﻿using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    public class SecurityProfileSecurityProfilePermissionAssignmentDto
    {
        public SecurityProfilePermissionDto Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }

}
