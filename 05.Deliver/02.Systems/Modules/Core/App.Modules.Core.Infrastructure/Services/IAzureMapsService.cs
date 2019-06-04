using App.Modules.Core.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAzureMapsService : IModuleSpecificService, IAzureService
    {
        AzureMapsSearchResponse AddressSearch(string searchTerm, string countrySetCsv, bool typeAhead = true);

        AzureMapsReverseSearchResponse ReverseAddressSearch(decimal latitude, decimal longtitude);
    }
}
