// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Models;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Messages.API.V0100
{
    /// <summary>
    ///     DTO for Roles
    /// </summary>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasRecordState" />
    public class RoleDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasRecordState
    {
        /// <summary>
        ///     TODO: Gets or sets the module key.
        /// </summary>
        /// <value>
        ///     The module key.
        /// </value>
        public string ModuleKey { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="RoleDto" /> is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public virtual bool Enabled { get; set; }


        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        public virtual string Key { get; set; }

        /// <summary>
        ///     Gets or sets the data classification.
        /// </summary>
        /// <value>
        ///     The data classification.
        /// </value>
        public DataClassificationDto DataClassification { get; set; }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the logical state of the record:
        /// </summary>
        /// <value>
        ///     The state of the record.
        /// </value>
        public virtual RecordPersistenceState RecordState { get; set; }
    }
}