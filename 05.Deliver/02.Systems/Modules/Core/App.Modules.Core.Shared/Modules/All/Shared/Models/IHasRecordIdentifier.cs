// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for entities that reference
    ///     other records. Eg SearchResults
    ///     <para>
    ///         See <see cref="IHasRecordSerializedIdentifier" />
    ///     </para>
    /// </summary>
    public interface IHasRecordIdentifier
    {
        /// <summary>
        ///     Gets or sets the identifier of the record identifier.
        /// </summary>
        string RecordTypeIdentifier { get; set; }

        /// <summary>
        ///     Gets or sets id of the record.
        /// </summary>
        string RecordIdentifier { get; set; }
    }
}