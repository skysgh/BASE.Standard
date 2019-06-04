using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Modules.Core.Infrastructure.Services.Implementations.Base;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
    using Microsoft.ApplicationInsights;

    /// <summary>
    ///     Implementation of the
    ///     <see cref="ITelemetryService" />
    ///     Infrastructure Service Contract
    /// </summary>
    /// <seealso cref="App.Modules.Core.Infrastructure.Services.ITelemetryService" />
    public class TelemetrySevice : AppCoreServiceBase, ITelemetryService
    {
        public void TrackEvent(string message)
        {

            new TelemetryClient().TrackEvent(message);
        }
    }
}
