using Microsoft.Extensions.Configuration;
using ServiceStack.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisCacheWebAP.CacheLib
{
    public abstract class BaseCacheClass
    {
        public abstract void Init(IConfiguration configuration);

        public abstract ICacheClient GetCacheClient();
    }
}
