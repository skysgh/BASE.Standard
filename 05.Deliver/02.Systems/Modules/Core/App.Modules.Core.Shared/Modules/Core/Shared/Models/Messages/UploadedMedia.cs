namespace App.Modules.Core.Shared.Models.Messages
{
    // A model to summarize what has been uploaded by an end user.
    // Not persistable (see MediaMetadata).
    public class UploadedMedia
    {
        public long Length { get; set; }
        public byte[] Stream { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
    }
}
