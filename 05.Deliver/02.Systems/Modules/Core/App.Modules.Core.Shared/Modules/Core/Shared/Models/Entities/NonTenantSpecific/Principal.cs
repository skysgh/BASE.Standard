using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// <para>
    /// It's *not* called User because a security Principal can be a User, but also a Device or Service.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.Entities.UntenantedRecordStatedTimestampedGuidIdEntityBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabled" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasDataClassification" />
    public class Principal : UntenantedRecordStatedTimestampedGuidIdEntityBase
        , IHasEnabled
    , IHasDataClassification
    , IHasEnabledBeginningUtcDateTime,
        IHasEnabledEndUtcDateTime
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Principal"/> class.
        /// </summary>
        public Principal()
        {
        }

        /// <summary>
        /// Gets or sets when the the record will be disabled.
        /// </summary>
        public DateTimeOffset? EnabledBeginningUtcDateTime { get; set; }
        /// <summary>
        /// Gets or sets the future UTC date time
        /// when the object will be disabled.
        /// <para><see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /></para>
        /// </summary>
        public DateTimeOffset? EnabledEndingUtcDateTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:App.Modules.All.Shared.Models.IHasEnabled" /> is enabled.
        /// <para>
        /// See <see cref="T:App.Modules.All.Shared.Models.IHasEnabledBeginningUtcDateTime" />
        /// and <see cref="T:App.Modules.All.Shared.Models.IHasEnabledEndUtcDateTime" /></para>
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public virtual string FullName { get; set; }

        /// <summary>
        /// This is there Name that they set
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the FK of the
        /// data classification.
        /// </summary>
        public virtual NZDataClassification DataClassificationFK { get => _dataClassificationFK; set => _dataClassificationFK = value; }
        private NZDataClassification _dataClassificationFK = NZDataClassification.Unclassified;

        /// <summary>
        /// Gets or sets the data classification of this entity.
        /// </summary>
        public virtual DataClassification DataClassification { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public virtual PrincipalCategory Category { get; set; }
        /// <summary>
        /// Gets or sets the category fk.
        /// </summary>
        /// <value>
        /// The category fk.
        /// </value>
        public virtual Guid CategoryFK { get; set; }


        /// <summary>
        /// Gets or sets the logins.
        /// </summary>
        /// <value>
        /// The logins.
        /// </value>
        public virtual ICollection<PrincipalLogin> Logins
        {
            get
            {
                if (this._logins == null)
                {
                    this._logins = new Collection<PrincipalLogin>();
                }
                return this._logins;
            }
            set => this._logins = value;
        }
        private ICollection<PrincipalLogin> _logins;


        /// <summary>
        /// Gets or sets the tag assignment.
        /// </summary>
        /// <value>
        /// The tag assignment.
        /// </value>
        public virtual ICollection<PrincipalTagAssignment> TagAssignment
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<PrincipalTagAssignment>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }
        private ICollection<PrincipalTagAssignment> _tags;





        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public virtual ICollection<PrincipalProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<PrincipalProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<PrincipalProperty> _properties;

        /// <summary>
        /// Gets or sets the claims.
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        public virtual ICollection<PrincipalClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<PrincipalClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<PrincipalClaim> _claims;





        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public virtual ICollection<SystemRole> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new Collection<SystemRole>();
                }
                return this._roles;
            }
            set => this._roles = value;
        }
        private ICollection<SystemRole> _roles;
    }
}