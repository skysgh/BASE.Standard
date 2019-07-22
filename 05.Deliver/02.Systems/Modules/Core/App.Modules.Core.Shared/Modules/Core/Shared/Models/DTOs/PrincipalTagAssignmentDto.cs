// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     Gets or sets the child Tag DTO associated to a parent
    ///     <see cref="PrincipalDto" />.
    /// </summary>
    public class PrincipalTagAssignmentDto
    {
        /// <summary>
        /// Gets or sets the parent <see cref="Principal"/>.
        /// </summary>
        /// <value>
        /// The principal.
        /// </value>
        public virtual PrincipalDto Principal { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public virtual PrincipalTagDto Tag { get; set; }
    }
}