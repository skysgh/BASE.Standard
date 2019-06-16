namespace App.Modules.All.Shared.Models
{
    /// <summary>
    /// Contract for objects that define a remote Image.
    /// </summary>
    public interface IHasImageUrl
    {
        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        string ImageUrl { get; set; }
    }


}