using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.All.Infrastructure.Services;
using App.Modules.Core.Shared.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IGeoIPService : IInfrastructureService
    {

        GeoInformation Get(string ip);

    }
}
