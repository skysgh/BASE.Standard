// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;

namespace App.Modules.Core.Infrastructure.Services.Caches.Implementations
{
    /// <summary>
    ///     Static cache that is injected into
    ///     IHostSettingsService.
    /// </summary>
    public static class HostSettingsServiceConfigurationObjectCache
    {
        public static Dictionary<string, object> ObjectCache { get; } = new Dictionary<string, object>();
    }
}