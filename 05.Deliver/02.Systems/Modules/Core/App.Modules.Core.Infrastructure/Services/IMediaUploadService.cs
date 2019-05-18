namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Models.Entities;
    using App.Modules.Core.Shared.Models.Messages;
    using App.Modules.Core.Shared.Contracts.Services;


    public interface IMediaUploadService : IModuleSpecificService
    {
        void Process(UploadedMedia mediaStream, NZDataClassification dataClassification);

    }
}