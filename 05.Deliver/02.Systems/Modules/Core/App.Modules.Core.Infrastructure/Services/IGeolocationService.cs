using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Models.Messages;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IGeoIPService : IModuleSpecificService
    {

        GeoInformation Get(string ip);

    }
}
