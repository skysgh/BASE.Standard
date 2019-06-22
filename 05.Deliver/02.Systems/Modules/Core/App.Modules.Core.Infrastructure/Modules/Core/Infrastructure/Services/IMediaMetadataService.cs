// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Entities;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IMediaMetadataService : IInfrastructureService
    {
        MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification);
    }
}