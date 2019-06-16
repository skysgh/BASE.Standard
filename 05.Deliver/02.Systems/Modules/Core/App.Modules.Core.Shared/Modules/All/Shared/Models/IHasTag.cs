namespace App.Modules.All.Shared.Models
{
    /// Contract for a model that has a
    /// <see cref="Tag"/>
    /// property.
    public interface IHasTag
    {
        /// <summary>
        /// Gets or sets the Tag
        /// associated to the record.
        /// </summary>
        string Tag { get; set; }
    }
}