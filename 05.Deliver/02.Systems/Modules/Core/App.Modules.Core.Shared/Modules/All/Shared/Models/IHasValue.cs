namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="Value"/>
    /// property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHasValue<T>
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        T Value { get; set; }
    }
}