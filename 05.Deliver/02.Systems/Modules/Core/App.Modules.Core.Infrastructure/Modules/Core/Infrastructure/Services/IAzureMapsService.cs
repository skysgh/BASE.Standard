using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAzureMapsService : IInfrastructureService, IAzureService
    {
        AzureMapsSearchResponse AddressSearch(string searchTerm, string countrySetCsv, bool typeAhead = true);

        AzureMapsReverseSearchResponse ReverseAddressSearch(decimal latitude, decimal longtitude);
    }
}
