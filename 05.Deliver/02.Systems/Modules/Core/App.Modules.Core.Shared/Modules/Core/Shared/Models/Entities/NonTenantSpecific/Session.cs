﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    /// <para>
    /// A Session is bound to a single <see cref="Principal"/>
    /// but not to a single <see cref="Tenant"/>.
    /// </para>
    /// </summary>
    public class Session : UntenantedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled, IHasPrincipalFK,
        IHasDateTimeCreatedUtc
    {
        private string _uniqueId;

        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        public Session():base()
        {
            // By default, until overridden 
            // when hydrated by EF from a db
            // record:
            Enabled = true;
            
        }

        /// <summary>
        /// Gets or sets whether a Session is enabled.
        /// <para>
        /// A Security Specialist could disable an active session
        /// if the session is believed to be a risk.
        /// </para>
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// A unique Id so that It can be identified
        /// </summary>
        public virtual string UniqueIdentifier
        {
            get => !string.IsNullOrWhiteSpace(_uniqueId) ? _uniqueId : this.Id.ToString();
            set => _uniqueId = value;
        }

        /// <summary>
        /// Gets or sets the UTC date time when the record was created.
        /// </summary>
        public DateTimeOffset UtcDateTimeCreated { get; set; }

        /// <summary>
        /// Gets or sets the FK of the Principal 
        /// who initiated the Session.
        /// </summary>
        public virtual Guid PrincipalFK { get; set; }
        /// <summary>
        /// Get or sets the Principal
        /// who initiated the Session.
        /// </summary>
        public virtual Principal Principal { get; set; }

        // A Session is bound to a Principal, 
        // but not Bound to a single Tenant (as a User
        // can switch Tenants):
        // NO: public Tenant Tenant { get; set; }
        // NO: public Guid TenantFK { get; set; }


            /// <summary>
            /// Gets a collection of all <see cref="SessionOperation"/>s
            /// performed by the <see cref="Principal"/> during this 
            /// <see cref="Session"/>.
            /// </summary>
        public virtual ICollection<SessionOperation> Operations
        {
            get
            {
                if (this._operations == null)
                {
                    this._operations = new Collection<SessionOperation>();
                }
                return this._operations;
            }
            set => this._operations = value;
        }


        private ICollection<SessionOperation> _operations;

    }
}