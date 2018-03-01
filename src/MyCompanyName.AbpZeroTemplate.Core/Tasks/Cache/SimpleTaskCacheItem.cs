using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks.Cache
{
    [AutoMapFrom(typeof(SimpleTask))]
    public class SimpleTaskCacheItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskState State { get; set; }
    }
}
