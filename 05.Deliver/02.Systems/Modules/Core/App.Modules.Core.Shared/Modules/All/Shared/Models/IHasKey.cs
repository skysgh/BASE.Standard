namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that
    /// has a <see cref="Key"/> property.
    /// </summary>
    public interface IHasKey
    {
        /// <summary>
        /// Gets or sets the unique key of the object,
        /// by which it is indexed when persisted
        /// (in additional to any primary Id).
        /// <para>
        /// Not the same as <see cref="IHasName"/>
        /// </para>.
        /// </summary>
        string Key { get; set; }
    }
}