namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for a model that has a
    /// <see cref="Title"/>
    /// property.
    /// </summary>
    public interface IHasTitle
    {
        /// <summary>
        /// Gets or sets the title of the model.
        /// </summary>
        string Title { get; set; }
    }


}