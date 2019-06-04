using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Contracts.Services;

    public interface IMediaMetadataService : IModuleSpecificService
    {
        MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification);
    }
}