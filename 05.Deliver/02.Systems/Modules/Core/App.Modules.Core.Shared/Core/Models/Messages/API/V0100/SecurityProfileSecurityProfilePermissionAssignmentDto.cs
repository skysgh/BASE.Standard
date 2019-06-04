using App.Modules.Core.Models.Entities;

namespace App.Modules.Core.Models.Messages.API.V0100
{
    public class SecurityProfileSecurityProfilePermissionAssignmentDto
    {
        public SecurityProfilePermissionDto Permission { get; set; }

        public AssignmentType AssignmentType { get; set; }
    }

}
