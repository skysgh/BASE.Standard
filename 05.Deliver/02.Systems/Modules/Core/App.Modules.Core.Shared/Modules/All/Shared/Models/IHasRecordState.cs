// Copyright MachineBrains, Inc. 2019

using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that has a
    ///     <see cref="RecordState" />
    ///     property.
    /// </summary>
    public interface IHasRecordState
    {
        /// <summary>
        ///     Gets or sets the logical state of the record:
        /// </summary>
        /// <value>
        ///     The state of the record.
        /// </value>
        RecordPersistenceState RecordState { get; set; }
    }
}