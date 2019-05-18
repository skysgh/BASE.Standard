﻿using App.Modules.Core.Shared.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.Services
{
    public interface IGeoIPService : IModuleSpecificService
    {

        GeoInformation Get(string ip);

    }
}
