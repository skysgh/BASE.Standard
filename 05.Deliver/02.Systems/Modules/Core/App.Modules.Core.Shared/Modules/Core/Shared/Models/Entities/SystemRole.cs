// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     Roles within this System (not the same as Claims Roles that came in via remote IdP)
    ///     And not the same as custom Tenant roles (still to solve).
    /// </summary>
    public class SystemRole
        : UntenantedRecordStatedTimestampedGuidIdEntityBase
            , IHasEnabled, IHasKey, IHasDataClassification
    {
        /// <summary>
        ///     Module within which the Role was developed/designed for.
        /// </summary>
        public virtual string ModuleKey { get; set; }


        /// <summary>
        ///     Gets or sets the FK of the
        ///     data classification.
        /// </summary>
        public virtual NZDataClassification DataClassificationFK { get; set; }

        /// <summary>
        ///     Gets or sets the data classification of this entity.
        /// </summary>
        public virtual DataClassification DataClassification { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        ///     <para>
        ///         See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        ///         and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" />
        ///     </para>
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        ///     The in-system rolename.
        /// </summary>
        public virtual string Key { get; set; }
    }
}