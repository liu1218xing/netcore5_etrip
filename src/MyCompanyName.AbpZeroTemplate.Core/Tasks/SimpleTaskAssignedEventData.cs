using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks
{
    public class TaskAssignedEventData : SimpleTaskEventData
    {
        public User User { get; set; }
        public TaskAssignedEventData(SimpleTask task, User user)
        {
            this.Task = task;
            this.User = user;
        }
    }
}
