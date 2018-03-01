using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks.Cache
{
    public interface ISimpleTasksCache
    {
        SimpleTaskCacheItem GetTaskFromCacheById(int taskId);
    }
}
