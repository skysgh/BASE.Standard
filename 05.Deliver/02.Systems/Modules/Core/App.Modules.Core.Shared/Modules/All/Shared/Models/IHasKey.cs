// Copyright MachineBrains, Inc. 2019

namespace App.Modules.All.Shared.Models
{
    /// <summary>
    ///     Contract for a model that
    ///     has a <see cref="Key" /> property.
    /// <para>
    /// Note the difference with
    /// <see cref="IHasKey"/> which is used to define
    /// which attribute of an object is used as the
    /// primary index key (and is not necessarily
    /// the same as it's <see cref="IHasName"/>)
    /// </para>
    /// <para>
    /// Note <see cref="IHasTitle"/>, which is used
    /// for containing displayable information.
    /// </para>
    /// </summary>
    public interface IHasKey
    {
        /// <summary>
        ///     Gets or sets the unique key of the object,
        ///     by which it is indexed when persisted
        ///     (in additional to any primary Id).
        /// <para>
        /// Note the difference with
        /// <see cref="IHasKey"/> which is used to define
        /// which attribute of an object is used as the
        /// primary index key (and is not necessarily
        /// the same as it's <see cref="IHasName"/>)
        /// </para>
        /// <para>
        /// Note <see cref="IHasTitle"/>, which is used
        /// for containing displayable information.
        /// </para>
        /// </summary>
        string Key { get; set; }
    }
}