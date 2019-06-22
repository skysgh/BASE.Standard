// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// Contract for a model that has a
    /// <see cref="SerializedTypeName" />
    /// and
    /// <see cref="SerializedTypeValue" />
    /// property.
    public interface IHasSerializedTypeValue
    {
        /// <summary>
        ///     Gets or sets the fullname (not FQN) of the serialized .NET type.
        /// </summary>
        string SerializedTypeName { get; set; }

        /// <summary>
        ///     Gets or sets the serialized type value.
        /// </summary>
        string SerializedTypeValue { get; set; }
    }
}