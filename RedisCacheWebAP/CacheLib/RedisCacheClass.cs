using Microsoft.Extensions.Configuration;
using ServiceStack.Caching;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCacheWebAP.CacheLib
{
    public class RedisCacheClass : BaseCacheClass
    {
        private static RedisManagerPool RedisManagerPool = null;

        public override void Init(IConfiguration configuration)
        {
            if (RedisManagerPool == null)
            {
                RedisManagerPool = new RedisManagerPool(configuration.GetConnectionString("RedisConnection"));
            }
        }

        public override ICacheClient GetCacheClient()
        {
            return RedisManagerPool.GetCacheClient();
        }
    }
}
