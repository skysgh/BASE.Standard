namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="Parent"/>
    /// property.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="App.Modules.All.Shared.Models.IHasOptionalParentFK" />
    public interface IHasParent<T> : IHasOptionalParentFK
    {
        /// <summary>
        /// Gets or sets the optional parent object.
        /// </summary>
        T Parent { get; set; }
    }


}