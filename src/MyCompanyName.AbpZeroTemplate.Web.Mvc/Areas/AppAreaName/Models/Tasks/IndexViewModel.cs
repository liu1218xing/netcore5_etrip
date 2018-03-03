using Microsoft.AspNetCore.Mvc.Rendering;
using MyCompanyName.AbpZeroTemplate.Tasks;
using MyCompanyName.AbpZeroTemplate.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Tasks
{
    public class IndexViewModel
    {
        /// <summary>
        /// 用来进行绑定列表过滤状态
        /// </summary>
        public TaskState? SelectedTaskState { get; set; }

        /// <summary>
        /// 列表展示
        /// </summary>
        public IReadOnlyList<SimpleTaskDto> Tasks { get; }

        /// <summary>
        /// 创建任务模型
        /// </summary>
        public CreateSimpleTaskInput CreateTaskInput { get; set; }

        /// <summary>
        /// 更新任务模型
        /// </summary>
        public UpdateSimpleTaskInput UpdateTaskInput { get; set; }

        public IndexViewModel(IReadOnlyList<SimpleTaskDto> items)
        {
            Tasks = items;
        }

        /// <summary>
        /// 用于过滤下拉框的绑定
        /// </summary>
        /// <returns></returns>

        public List<SelectListItem> GetTaskStateSelectListItems()
        {
            var list = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "AllTasks",
                    Value = "",
                    Selected = SelectedTaskState==null
                }
            };

            list.AddRange(Enum.GetValues(typeof(TaskState))
                .Cast<TaskState>()
                .Select(state => new SelectListItem()
                {
                    Text = $"TaskState_{state}",
                    Value = state.ToString(),
                    Selected = state == SelectedTaskState
                })
            );

            return list;
        }
    }
}
