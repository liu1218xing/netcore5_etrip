using Abp.Domain.Services;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks
{
   public interface ISimpleTaskManager : IDomainService
    {
        void AssignTaskToPerson(SimpleTask task, User user);
    }
}
