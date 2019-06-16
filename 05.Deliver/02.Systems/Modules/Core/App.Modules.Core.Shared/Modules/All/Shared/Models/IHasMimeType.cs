namespace App.Modules.All.Shared.Models
{


    /// <summary>
    /// Contract for entities that record MimeType (eg: Media uploads for one)
    /// </summary>
    public interface IHasMimeType
    {
        /// <summary>
        /// Gets or sets the MIME type of the Media.
        /// <para>
        /// Note: The extension is not always a correct indicator...
        /// </para>
        /// </summary>
        string MimeType { get; set; }
    }




}
