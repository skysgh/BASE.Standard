// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A <see cref="TenantSecurityProfile" />
    ///     has both a set of <see cref="TenantSecurityProfilePermission" />s
    ///     as well as a set of <see cref="TenantSecurityProfileResponsibility" />s.
    /// </summary>
    public class TenantSecurityProfileResponsibility : TenantFKRecordStatedTimestampedGuidIdEntityBase,
        IHasTitleAndDescription
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantSecurityProfileResponsibility" /> class.
        /// </summary>
        public TenantSecurityProfileResponsibility()
        {
            Enabled = true;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="TenantSecurityProfileResponsibility" /> is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>
        ///     The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }
    }
}