// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Infrastructure.Configuration.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
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

        public MediaMetadataService(MediaMetadataServiceConfiguration metadataServiceConfiguration,
            IHostSettingsService hostSettingsService, IUniversalDateTimeService universalDateTimeService)
        {
            _metadataServiceConfiguration = metadataServiceConfiguration;
            _universalDateTimeService = universalDateTimeService;
        }

        //Service to create a metadata object that describes the uploaded Media file.
        public MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification)
        {
            var result = new MediaMetadata();

            result.ContentSize = uploadedMedia.Length;
            result.SourceFileName = uploadedMedia.FileName;
            result.DataClassificationFK = dataClassification;
            result.ContentHash =
                uploadedMedia.Stream.GetHashAsString(
                    _metadataServiceConfiguration.HashType);
            result.MimeType = uploadedMedia.ContentType ?? "Unknown";

            result.UploadedDateTimeUtc = _universalDateTimeService.NowUtc().UtcDateTime;

            return result;
        }
    }
}