using Abp.Dependency;
using Abp.Domain.Entities.Caching;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks.Cache
{
    public class SimpleTaskCache : EntityCache<SimpleTask, SimpleTaskCacheItem>, ISimpleTaskCache, ISingletonDependency
    {
        public SimpleTaskCache(ICacheManager cacheManager, IRepository<SimpleTask, int> repository, string cacheName = null)
            : base(cacheManager, repository, cacheName)
        {
        }
    }
}
