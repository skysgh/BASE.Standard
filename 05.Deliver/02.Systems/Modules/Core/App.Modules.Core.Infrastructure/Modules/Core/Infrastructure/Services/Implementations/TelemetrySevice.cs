// Copyright MachineBrains, Inc. 2019

using App.Modules.All.Infrastructure.Services;
using Microsoft.ApplicationInsights;

namespace App.Modules.Core.Infrastructure.Services.Implementations
{
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