namespace App.Modules.Core.Infrastructure.Caching
{
    public interface IAppCoreCacheItem
    {
        object Get();
        // TODO: abstract T Get(string subKey);
    }

}
