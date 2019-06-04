using App.Modules.Core.Models.Entities;
using App.Modules.Core.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    using App.Modules.Core.Shared.Contracts.Services;


    public interface IMediaUploadService : IModuleSpecificService
    {
        void Process(UploadedMedia mediaStream, NZDataClassification dataClassification);

    }
}