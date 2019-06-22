// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.All.Shared.Factories;
using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     Base class for DTO objects.
    ///     <para>
    ///         Most DTO messages developed in Modules -- bar Core --
    ///         will inherit from this base class.
    ///     </para>
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Messages.TenantedRecordStatedDtoBase" />
    /// <seealso cref="App.Modules.All.Shared.Models.IHasGuidId" />
    public abstract class
        TenantedRecordStateGuidIdDtoBase : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
            TenantedRecordStatedDtoBase, IHasGuidId
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TenantedRecordStateGuidIdDtoBase" /> class.
        /// </summary>
        protected TenantedRecordStateGuidIdDtoBase()
        {
            Id = GuidFactory.NewGuid();
        }

        /// <summary>
        ///     Gets or sets the identifier.
        /// </summary>
        /// <value>
        ///     The identifier.
        /// </value>
        public virtual Guid Id { get; set; }
    }
}