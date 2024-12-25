using Microsoft.Extensions.Caching.Memory;
using Taboo.ExternalServices.Abstracts;

namespace Taboo.ExternalServices.Implements
{
    public class LocalCacheService(IMemoryCache _cache) : ICacheService
    {

        public async Task<T?> GetAsync<T>(string key)
        {
            T? value = default(T);
            await Task.Run(() => { _cache.TryGetValue(key, out value); });
            return value;
        }

        public async Task RemoveAsync<T>(string key)
        {
            await Task.Run(() => _cache.Remove(key));
        }

        public async Task SetAsync<T>(string key, T data, int minute = 1)
        {
            await Task.Run(() => { _cache.Set<T>(key, data, DateTimeOffset.Now.AddMinutes(minute)); });

        }
    }
}
