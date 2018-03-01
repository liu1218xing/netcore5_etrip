using Abp.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.IRepositories;
using MyCompanyName.AbpZeroTemplate.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.EntityFrameworkCore.Repositories
{
    public class BackendTaskRepository : AbpZeroTemplateRepositoryBase<SimpleTask>, IBackendTaskRepository
    {
        public BackendTaskRepository(IDbContextProvider<AbpZeroTemplateDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 获取某个用户分配了哪些任务
        /// </summary>
        /// <param name="personId">用户Id</param>
        /// <returns>任务列表</returns>
        public List<SimpleTask> GetTaskByAssignedPersonId(long personId)
        {
            var query = GetAll();

            if (personId > 0)
            {
                query = query.Where(t => t.AssignedPersonId == personId);
            }

            return query.ToList();
        }
    }
}
