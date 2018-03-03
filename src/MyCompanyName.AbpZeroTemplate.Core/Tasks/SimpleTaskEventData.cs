using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks
{
    public class SimpleTaskEventData : EventData
    {
        public SimpleTask Task { get; set; }
    }
}
