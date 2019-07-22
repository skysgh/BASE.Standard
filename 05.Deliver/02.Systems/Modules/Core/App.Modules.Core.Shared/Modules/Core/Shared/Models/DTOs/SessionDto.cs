// Copyright MachineBrains, Inc. 2019

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.DTOs
{
    /// <summary>
    ///     DTO
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasEnabled" />
    public class SessionDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasEnabled
    {
        private ICollection<SessionOperationDto> _operations;

        /// <summary>
        ///     Gets or sets the start date time UTC.
        /// </summary>
        /// <value>
        ///     The start date time UTC.
        /// </value>
        public virtual DateTimeOffset StartDateTimeUtc { get; set; }

        /// <summary>
        ///     Gets or sets the principal.
        /// </summary>
        /// <value>
        ///     The principal.
        /// </value>
        public virtual Principal Principal { get; set; }


        /// <summary>
        ///     Gets or sets the operations.
        /// </summary>
        /// <value>
        ///     The operations.
        /// </value>
        public virtual ICollection<SessionOperationDto> Operations
        {
            get
            {
                if (_operations == null)
                {
                    _operations = new Collection<SessionOperationDto>();
                }

                return _operations;
            }
            set => _operations = value;
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
    }
}