﻿using App.Modules.Core.Shared.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IAzureMapsService : IAppModuleCoreService, IAzureService
    {
        AzureMapsSearchResponse AddressSearch(string searchTerm, string countrySetCsv, bool typeAhead = true);
        AzureMapsReverseSearchResponse ReverseAddressSearch(decimal latitude, decimal longtitude);
    }
}
