using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Caching
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache? _cache;
        public RedisCacheManager(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key, Func<T> acquire)
        {
            return Get(key, 30, acquire);
        }

        public T Get<T>(string key, int cacheTime, Func<T> acquire)
        {
            if (IsSet(key))
            {
                return Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (cacheTime > 0)
                    Set(key, result, cacheTime);
                return result;
            }
        }

        public T Get<T>(string key)
        {
            var jsonData = _cache.GetString(key);
            if (jsonData == null)
                return default(T);
            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public void Set(string key, object data, int cacheTime)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheTime)
            };
            var jsonData = JsonSerializer.Serialize(data);
            _cache.SetString(key, jsonData, options);
        }

        public object Get(string key)
        {
            return _cache.GetString(key);
        }

        public bool IsSet(string key)
        {
            return (_cache.GetString(key) != null);
        }



        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

    }
}
