using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Ordero.Core.Caching
{
    public class WebCacheManager : ICacheManager
    {
        private readonly HttpContextBase _httpContext;

        public WebCacheManager(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public T Get<T>(string key)
        {
            return (T)_httpContext.Cache.Get(key);
        }

        public bool IsSet(string key)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object data, int cacheTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheTime">Cache time in minutes</param>
        public T Set<T>(string key, object value, int cacheTime)
        {
            return Set<T>(key, value, null, DateTime.Now.AddMinutes(cacheTime), TimeSpan.Zero, CacheItemPriority.Normal, null);
        }

        public T Set<T>(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            _httpContext.Cache.Add(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);

            return (T)value;
        }
    }
}
