using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.Services.Utilities.Caching {

    public class DefaultCache : Cache {

        private static DefaultCache cachingProviderBase = null;
        private MemoryCache memoryCache = null;
        private object padlock;

        private readonly string cacheName = "cache";

        private DefaultCache() {

            this.memoryCache = new MemoryCache(cacheName);
            this.padlock = new object();

        }

        public static DefaultCache Instance() {

            if (cachingProviderBase == null) {

                cachingProviderBase = new DefaultCache();

            }

            return cachingProviderBase;

        }

        public void Add(string key, object value) {
            lock (padlock) {
                memoryCache.Add(key, value, DateTimeOffset.MaxValue);
            }
        }

        public void Remove(string key) {
            lock (padlock) {
                memoryCache.Remove(key);
            }
        }

        public object Get(string key) {
            lock (padlock) {
                return memoryCache[key];
            }
        }

        public bool ContainsKey(string key) {
            lock (padlock) {
                return memoryCache.Contains(key);
            }
        }

    }

}
