using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Tasks
{
    public interface ISimpleTaskAppService : IApplicationService
    {
        GetSimpleTasksOutput GetTasks(GetSimpleTasksInput input);

        PagedResultDto<SimpleTaskDto> GetPagedTasks(GetSimpleTasksInput input);

        void UpdateTask(UpdateSimpleTaskInput input);

        int CreateTask(CreateSimpleTaskInput input);

        Task<SimpleTaskDto> GetTaskByIdAsync(int taskId);

        SimpleTaskDto GetTaskById(int taskId);

        void DeleteTask(int taskId);

        

        IList<SimpleTaskDto> GetAllTasks();
    }
    
}
