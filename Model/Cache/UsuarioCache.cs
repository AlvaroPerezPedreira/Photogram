using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Caching;
using Es.Udc.DotNet.PracticaMaD.Model.ImageService;

namespace Es.Udc.DotNet.PracticaMaD.Model.Cache
{
    public static class UsuarioCache
    {
        // Mapa clave valor (loginname+startindex - CacheItem)
        private static MemoryCache cache;

        private static List<string> keys = new List<string>();
        private static readonly int MAX_SIZE = 12;

        static UsuarioCache()
        {
            cache = new MemoryCache("UsuarioCache");
        }

        public static void Add(string cacheKey, object value, bool existMore, int startIndex)
        {
            var cacheItem = new CacheItem<List<ImageSet>>((List<ImageSet>) value, existMore, startIndex);
            cache.Add(cacheKey, cacheItem, new CacheItemPolicy());
            keys.Add(cacheKey);

            if(keys.Count > MAX_SIZE)
            {
                // removes last item if cache size exceeds MAX_SIZE
                var key = keys[0];
                cache.Remove(key);
                keys.Remove(key);
            }
        }

        public static bool Exists(string cacheKey)
        {
            return cache.Contains(cacheKey);
        }

        public static bool ContainsFromIndexToIndex(string cacheKey, int startIndex)
        {
            var cacheItem = (CacheItem<List<ImageSet>>) cache.Get(cacheKey);

            //
            if(cacheItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ImageBlock Get(string cacheKey, int startIndex, int count)
        {
            var cachedItem = (CacheItem<List<ImageSet>>) cache.Get(cacheKey);

            // Si el cacheItem es null, return null
            if (cachedItem == null)
            {
                return null;
            }
            var cachedImages = cachedItem.Value;

            // Seleccionar el bloque correspondiente
            var selectedImages = cachedImages;
            bool existMoreImages = cachedItem.ExistMore;

            return new ImageBlock(selectedImages, existMoreImages);
        }

        public static void Remove(string cacheKey)
        {
            cache.Remove(cacheKey);
            keys.Remove(cacheKey);
        }
        public static void Dispose()
        {
            cache.Dispose();
            keys.Clear();
        }

    }
}