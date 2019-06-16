namespace App.Modules.Core.Shared.Models.Messages
{
    /// <summary>
    /// A model to summarize what has been uploaded by an end user.
    /// Not persistable (see MediaMetadata).
    /// </summary>
    public class UploadedMedia
    {
        /// <summary>
        /// Gets or sets the length of the media.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public long Length { get; set; }
        /// <summary>
        /// Gets or sets the stream.
        /// </summary>
        /// <value>
        /// The stream.
        /// </value>
        public byte[] Stream { get; set; }
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets the given name of the file.
        /// </summary>
        public string FileName { get; set; }
    }
}
