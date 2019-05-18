namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;
    using App.Modules.Core.Shared.Models.Messages;
    using App.Modules.Core.Shared.Contracts.Services;

    public interface IMediaMetadataService : IModuleSpecificService
    {
        MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification);
    }
}