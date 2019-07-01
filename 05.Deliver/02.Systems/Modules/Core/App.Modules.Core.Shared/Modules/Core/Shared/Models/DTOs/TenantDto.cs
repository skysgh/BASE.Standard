// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabled" />
    [Serializable]
    public class TenantDto
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : IHasGuidId, IHasEnabled, IHasKey
    {
        private ICollection<TenantClaimDto> _claims;
        private ICollection<TenantPropertyDto> _properties;

        /// <summary>
        ///     Gets or sets the name of the host.
        /// </summary>
        /// <value>
        ///     The name of the host.
        /// </value>
        public virtual string HostName { get; set; }

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        /// <value>
        ///     The display name.
        /// </value>
        public virtual string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        ///     Gets or sets the data classification.
        /// </summary>
        /// <value>
        ///     The data classification.
        /// </value>
        public DataClassificationDto DataClassification { get; set; }

        /// <summary>
        ///     Gets or sets the properties.
        /// </summary>
        /// <value>
        ///     The properties.
        /// </value>
        public virtual ICollection<TenantPropertyDto> Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new Collection<TenantPropertyDto>();
                }

                return _properties;
            }
            set => _properties = value;
        }

        /// <summary>
        ///     Gets or sets the claims.
        /// </summary>
        /// <value>
        ///     The claims.
        /// </value>
        public virtual ICollection<TenantClaimDto> Claims
        {
            get
            {
                if (_claims == null)
                {
                    _claims = new Collection<TenantClaimDto>();
                }

                return _claims;
            }
            set => _claims = value;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        ///     <para>
        ///         See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        ///         and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" />
        ///     </para>
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        ///     <para>
        ///         Not the same as <see cref="T:App.Modules.All.Shared.Models.IHasName" />
        ///     </para>
        ///     .
        /// </summary>
        public virtual string Key { get; set; }
    }
}