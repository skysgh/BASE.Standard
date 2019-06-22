// Copyright MachineBrains, Inc. 2019

namespace App.Modules.Core.Infrastructure.Caching
{
    public interface IAppCoreCacheItem
    {
        object Get();
        // TODO: abstract T Get(string subKey);
    }
}