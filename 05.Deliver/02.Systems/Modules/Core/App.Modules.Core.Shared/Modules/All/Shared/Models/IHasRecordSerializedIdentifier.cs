// Copyright MachineBrains, Inc. 2019

using System;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for objects that
    ///     have an attribute to record the Guid that represents
    ///     the remote FK.
    ///     TODO: This approach may be flawed and only one way if the Type is not a Guid.
    ///     <para>
    ///         See <see cref="IHasRecordIdentifier" />
    ///     </para>
    /// </summary>
    public interface IHasRecordSerializedIdentifier
    {
        /// <summary>
        ///     The target Record's Identifier value (almost always a Guid).
        ///     <para>
        ///         If the target record's key is a Guid, then you can reference that
        ///         directly.
        ///         But if the target has a composite key, or is an int, that is not feasible.
        ///         In which case, you have to convert it to something else (a Type 5 Guid
        ///         constructed from the SHA1 hash of a string -- eg a Json of they values).
        ///     </para>
        ///     <para>
        ///         They can't class as they are different classes
        ///         (Type 5 versus 4 for random
        ///         versus etc...)
        ///     </para>
        ///     <para>
        ///         Note that TenantFK information is not addressed
        ///         at this level/in this contract.
        ///     </para>
        /// </summary>
        Guid RecordIdentifier { get; set; }
    }
}