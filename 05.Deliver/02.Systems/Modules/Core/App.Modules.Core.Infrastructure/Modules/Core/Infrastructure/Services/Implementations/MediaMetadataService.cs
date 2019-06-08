
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using App.Modules.Core.Infrastructure.Services.Configuration.Implementations;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="IMediaMetadataService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IMediaMetadataService" />
    public class MediaMetadataService : AppCoreServiceBase, IMediaMetadataService
    {
        //private readonly IHostSettingsService _hostSettingsService;
        private readonly MediaMetadataServiceConfiguration _metadataServiceConfiguration;

        private readonly IUniversalDateTimeService _universalDateTimeService;

        public MediaMetadataService(MediaMetadataServiceConfiguration metadataServiceConfiguration, IHostSettingsService hostSettingsService, IUniversalDateTimeService universalDateTimeService)
        {
            this._metadataServiceConfiguration = metadataServiceConfiguration;
            this._universalDateTimeService = universalDateTimeService;

        }

        //Service to create a metadata object that describes the uploaded Media file.
        public MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification)
        {
            var result = new MediaMetadata();

            result.ContentSize = uploadedMedia.Length;
            result.SourceFileName = uploadedMedia.FileName;
            result.DataClassificationFK = dataClassification;
            result.ContentHash = uploadedMedia.Stream.GetHashAsString(this._metadataServiceConfiguration.MediaManagementConfiguration.HashType);
            result.MimeType = uploadedMedia.ContentType ?? "Unknown";

            result.UploadedDateTimeUtc = this._universalDateTimeService.NowUtc().UtcDateTime;

            return result;
        }
    }
}