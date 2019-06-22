// Copyright MachineBrains, Inc. 2019

using System.Collections.Generic;

namespace App.Modules.Core.Infrastructure.Services.Caches.Implementations
{
    /// <summary>
    ///     Static cache object injected into KeyVault Service.
    /// </summary>
    public static class KeyVaultServiceConfigurationObjectCache
    {
        public static Dictionary<string, object> ObjectCache { get; } = new Dictionary<string, object>();
    }
}