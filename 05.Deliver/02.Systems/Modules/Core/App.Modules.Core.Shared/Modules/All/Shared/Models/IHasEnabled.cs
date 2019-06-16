namespace App.Modules.All.Shared.Models

{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="Enabled"/>
    /// property.
    /// </summary>
    public interface IHasEnabled
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IHasEnabled"/> is enabled.
        /// <para>
        /// See <see cref="IHasEnabledBeginningUtcDateTime"/>
        /// and <see cref="IHasEnabledEndUtcDateTime"/>
        /// </para>
        /// </summary>
        bool Enabled { get; set; }
    }
}