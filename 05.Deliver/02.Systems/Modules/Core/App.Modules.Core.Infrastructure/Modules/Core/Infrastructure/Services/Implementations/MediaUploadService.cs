// Copyright MachineBrains, Inc. 2019

using System;
using App.Modules.Core.Infrastructure.Data.Db.Contexts;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    /// <summary>
    ///     Implementation of the
    ///     <see cref="IMediaUploadService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.IMediaUploadService" />
    public class MediaUploadService : AppCoreServiceBase, IMediaUploadService
    {
        private readonly ModuleDbContext _coreRepositoryService;
        private readonly IDiagnosticsTracingService _diagnosticsTracingService;
        private readonly IMediaMalwareDetectionService _mediaMalwareVerificationService;
        private readonly IMediaMetadataService _mediaMetadataService;
        private readonly IStorageService _storageService;
        private readonly IUniversalDateTimeService _universalDateTimeService;

        public MediaUploadService(IDiagnosticsTracingService diagnosticsTracingService,
            IUniversalDateTimeService universalDateTimeService,
            IStorageService storageService,
            IMediaMalwareDetectionService mediaMalwareVerificationService,
            IMediaMetadataService mediaMetadataService, ModuleDbContext repositoryService)
        {
            _diagnosticsTracingService = diagnosticsTracingService;
            _mediaMalwareVerificationService = mediaMalwareVerificationService;
            _mediaMetadataService = mediaMetadataService;
            _coreRepositoryService = repositoryService;
            _universalDateTimeService = universalDateTimeService;
            _storageService = storageService;
        }

        public void Process(UploadedMedia uploadedMedia, NZDataClassification dataClassification)
        {
            //First, build a summary of the uploaded file:
            var mediaMetadata =
                _mediaMetadataService.Create(uploadedMedia, dataClassification);


            ScanFile(ref uploadedMedia, ref mediaMetadata);
            if (mediaMetadata.LatestScanResults == "content.en.language.nsfw")
            {
                mediaMetadata.LatestScanMalwareDetetected = false;
            }

            if (mediaMetadata.LatestScanMalwareDetetected.HasValue &&
                mediaMetadata.LatestScanMalwareDetetected.Value == false)
            {
                //TODO: TO BE REVISITED
                mediaMetadata.LocalName = Guid.NewGuid().ToString();

                _storageService.Persist(uploadedMedia.Stream, mediaMetadata.LocalName);
            }

            _coreRepositoryService.AddOnCommit(mediaMetadata);
        }

        private void ScanFile(ref UploadedMedia uploadedMedia, ref MediaMetadata mediaMetadata)
        {
            var scanResults = _mediaMalwareVerificationService.Validate(uploadedMedia.Stream, uploadedMedia.FileName,
                uploadedMedia.ContentType);

            mediaMetadata.LatestScanDateTimeUtc = _universalDateTimeService.NowUtc().UtcDateTime;
            mediaMetadata.LatestScanResults = scanResults.LatestScanResults;
            mediaMetadata.LatestScanMalwareDetetected = scanResults.LatestScanMalwareDetected;
        }
    }
}