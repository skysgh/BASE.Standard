// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for models that have a Name (not automatically unique).
    ///     <para>
    ///         NOTE: prefer the use of <see cref="IHasKey" /> if the value is unique.
    ///     </para>
    ///     <para>
    ///         Consider also <see cref="IHasTitle" /> if it's just a displayable name.
    ///     </para>
    /// <para>
    /// Note the difference with
    /// <see cref="IHasName"/> which is used to
    /// the well-known name of an object, but is
    /// not necessarily it's <see cref="IHasKey"/>.
    /// </para>
    /// </summary>
    public interface IHasName
    {
        /// <summary>
        ///     Gets or sets the unique Name
        ///     of the object
        /// <para>
        /// Note the difference with
        /// <see cref="IHasName"/> which is used to
        /// the well-known name of an object, but is
        /// not necessarily it's <see cref="IHasKey"/>.
        /// </para>
        /// </summary>
        string Name { get; set; }
    }
}