using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// DTO
    /// </summary>
    public class SecurityProfileSecurityProfilePermissionAssignmentDto
    {
        /// <summary>
        /// Gets or sets the permission assigned to a PRofile.
        /// </summary>
        /// <value>
        /// The permission.
        /// </value>
        public SecurityProfilePermissionDto Permission { get; set; }

        /// <summary>
        /// Gets or sets the type of the assignment.
        /// </summary>
        /// <value>
        /// The type of the assignment.
        /// </value>
        public AssignmentType AssignmentType { get; set; }
    }

}
