// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Shared.Models.Entities;

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Interface used to create auditable records
    ///     of previous values of records that are changed.
    /// </summary>
    public interface IHasSerializedObject
    {
        /// <summary>
        ///     Gets or sets the serialized Type of the serialized value (ie, it's Type fullname).
        /// </summary>
        Guid SerializedObjectType { get; set; }

        /// <summary>
        ///     How were the records persisted (
        ///     as the years go by, different serializations
        ///     come and into vogue -- but you don't want to
        ///     have to do massive data migration operations
        ///     of live systems...).
        /// </summary>
        SerializedObjectSerializationMethod SerializedObjectSerializationMethod { get; set; }

        /// <summary>
        ///     The string value containing the serialization of the target
        ///     object's values.
        /// </summary>
        string SerializedObjectValues { get; set; }
    }
}