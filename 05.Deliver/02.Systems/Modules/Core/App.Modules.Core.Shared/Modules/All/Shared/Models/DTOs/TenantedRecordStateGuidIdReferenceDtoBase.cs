// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    ///     Base class for Reference data item DTO/Messages.
    /// </summary>
    /// <seealso cref="App.Modules.Core.Shared.Models.Messages.TenantedRecordStateGuidIdDtoBase" />
    public abstract class TenantedRecordStateGuidIdReferenceDtoBase
        /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
        : TenantedRecordStateGuidIdDtoBase, IHasTitleAndDescription
    {
        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public virtual string Title { get; set; }


        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public virtual string Description { get; set; }
    }
}