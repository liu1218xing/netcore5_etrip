using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks.Cache
{
    public class SimpleTaskFromCache : ISimpleTaskFromCache
    {
        
        private readonly ISimpleTaskCache _taskCache;


        /// <summary>
        ///     In constructor, we can get needed classes/interfaces.
        ///     They are sent here by dependency injection system automatically.
        /// </summary>
        public SimpleTaskFromCache(ISimpleTaskCache taskCache
            )
        {
            _taskCache = taskCache;
            
        }
        public SimpleTaskCacheItem GetTaskFromCacheById(int taskId)
        {
            return _taskCache[taskId];
        }
    }
}
