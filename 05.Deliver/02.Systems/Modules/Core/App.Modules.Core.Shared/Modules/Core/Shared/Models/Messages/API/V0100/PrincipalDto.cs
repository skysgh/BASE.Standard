using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    /// DTO for <see cref="Principal"/>
    /// objects.
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabled" />
    public class PrincipalDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasEnabled
    {
        private ICollection<PrincipalClaimDto> _claims;
        private ICollection<PrincipalPropertyDto> _properties;
        private ICollection<PrincipalTagDto> _tags;
        private ICollection<PrincipalLoginDto> _logins;
        private ICollection<RoleDto> _roles;

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the data classification.
        /// </summary>
        /// <value>
        /// The data classification.
        /// </value>
        public DataClassificationDto DataClassification { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public PrincipalCategoryDto Category { get; set; }


        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public ICollection<RoleDto> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new Collection<RoleDto>();
                }
                return this._roles;
            }
            set => this._roles = value;
        }

        /// <summary>
        /// Gets or sets the logins associated to this Principal.
        /// </summary>
        /// <value>
        /// The logins.
        /// </value>
        public ICollection<PrincipalLoginDto> Logins
        {
            get
            {
                if (this._logins == null)
                {
                    this._logins = new Collection<PrincipalLoginDto>();
                }
                return this._logins;
            }
            set => this._logins = value;
        }

        /// <summary>
        /// Gets or sets the tags associated to this entity.
        /// </summary>
        public virtual ICollection<PrincipalTagDto> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<PrincipalTagDto>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }

        /// <summary>
        /// Gets or sets the properties associated to this entity.
        /// </summary>
         public virtual ICollection<PrincipalPropertyDto> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<PrincipalPropertyDto>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }


        /// <summary>
        /// Gets or sets the claims.
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        public virtual ICollection<PrincipalClaimDto> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<PrincipalClaimDto>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        /// <para>
        /// See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        /// and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" /></para>
        /// </summary>
        public virtual bool Enabled { get; set; }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual Guid Id { get; set; }
    }
}