// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Shared.Models;

namespace App.Modules.Core.Shared.Models.Entities
{
    /// <summary>
    ///     Enumeration of ways to serialize objects
    ///     <para>
    ///         Refer to <see cref="IHasSerializedObject" />
    ///         which is ther interface used to persist an
    ///         auditable record of previous values, and who has made
    ///         changes.
    ///     </para>
    /// </summary>
    public enum SerializedObjectSerializationMethod
    {
        /// <summary>
        ///     An Error state.
        /// </summary>
        Undefined = 0,

        /// <summary>
        ///     Undetermined as of yet (used only when deserializing).
        /// </summary>
        Undetermined = 1,

        /// <summary>
        ///     A heavy means of serializing objects.
        /// </summary>
        Xml = 1,

        /// <summary>
        ///     A ligther way of serializing objects.
        /// </summary>
        Json = 3,

        /// <summary>
        ///     An almost humanly readable way of serializing objects.
        /// </summary>
        YAML = 4
    }
}