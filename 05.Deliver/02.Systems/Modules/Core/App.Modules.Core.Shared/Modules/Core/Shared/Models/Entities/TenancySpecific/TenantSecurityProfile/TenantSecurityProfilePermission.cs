// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     A tenant-specific Role that can be part of a <see cref="TenantSecurityProfileRole" />
    ///     or assigned directly to a <see cref="TenantSecurityProfile" />
    /// </summary>
    public class TenantSecurityProfilePermission : TenantFKRecordStatedTimestampedGuidIdEntityBase,
        IHasTitleAndDescription
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantSecurityProfilePermission" /> class.
        /// </summary>
        public TenantSecurityProfilePermission()
        {
            Enabled = true;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="TenantSecurityProfilePermission" /> is enabled.
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