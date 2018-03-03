using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks.Cache
{
   
    public interface ISimpleTaskFromCache
    {
        SimpleTaskCacheItem GetTaskFromCacheById(int taskId);
    }
}
