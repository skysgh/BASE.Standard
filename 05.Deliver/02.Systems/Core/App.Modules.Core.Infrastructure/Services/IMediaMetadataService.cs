namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Entities.TenancySpecific;
    using App.Modules.Core.Shared.Models.Messages;
    using App.Modules.Core.Shared.Services;

    public interface IMediaMetadataService : IHasAppCoreService
    {
        MediaMetadata Create(UploadedMedia uploadedMedia, NZDataClassification dataClassification);
    }
}