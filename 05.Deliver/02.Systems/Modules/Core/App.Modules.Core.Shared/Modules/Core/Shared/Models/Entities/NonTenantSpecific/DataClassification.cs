// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models.Entities;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     Entity to record
    ///     DataClassification of objects.
    /// </summary>
    /// <seealso cref="UntenantedRecordStatedTimestampedCustomIdReferenceDataEntityBase{TId}" />
    public class DataClassification
        : UntenantedRecordStatedTimestampedCustomIdReferenceDataEntityBase<NZDataClassification>
    {
    }
}