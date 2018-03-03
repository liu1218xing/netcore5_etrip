﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Caching;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using MyCompanyName.AbpZeroTemplate.Notifications;
using MyCompanyName.AbpZeroTemplate.Tasks;
using MyCompanyName.AbpZeroTemplate.Tasks.Dto;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Tasks;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;
using X.PagedList;

namespace MyCompanyName.AbpZeroTemplate.Web.Mvc.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_SimpleTasks)]
    public class SimpleTasksController : AbpZeroTemplateControllerBase
    {
        private readonly ISimpleTaskAppService _taskAppService;
        private readonly IUserAppService _userAppService;
        private readonly INotificationAppService _notificationAppService;
        private readonly ICacheManager _cacheManager;

        public SimpleTasksController(ISimpleTaskAppService taskAppService, IUserAppService userAppService, ICacheManager cacheManager, INotificationAppService notificationAppService)
        {
            _taskAppService = taskAppService;
            _userAppService = userAppService;
            _cacheManager = cacheManager;
            _notificationAppService = notificationAppService;
        }

        public ActionResult Index(GetSimpleTasksInput input)
        {
            var output = _taskAppService.GetTasks(input);

            var model = new IndexViewModel(output.Tasks)
            {
                SelectedTaskState = input.State
            };
            return View(model);
        }

        // GET: Tasks
        public ActionResult PagedList(int? page)
        {
            //每页行数
            var pageSize = 5;
            var pageNumber = page ?? 1; //第几页

            var filter = new GetSimpleTasksInput
            {
                SkipCount = (pageNumber - 1) * pageSize, //忽略个数
                MaxResultCount = pageSize
            };
            var result = _taskAppService.GetPagedTasks(filter);

            //已经在应用服务层手动完成了分页逻辑，所以需手动构造分页结果
            var onePageOfTasks = new StaticPagedList<SimpleTaskDto>(result.Items, pageNumber, pageSize, result.TotalCount);
            //将分页结果放入ViewBag供View使用
            ViewBag.OnePageOfTasks = onePageOfTasks;

            return View();
        }


        public PartialViewResult GetList(GetSimpleTasksInput input)
        {
            var output = _taskAppService.GetTasks(input);
            return PartialView("_List", output.Tasks);
        }

        /// <summary>
        /// 获取创建任务分部视图
        /// 该方法使用ICacheManager进行缓存，在WebModule中配置缓存过期时间为10mins
        /// </summary>
        /// <returns></returns>
        public PartialViewResult RemoteCreate()
        {
            //1.1 注释该段代码，使用下面缓存的方式
            //var userList = _userAppService.GetUsers();

            //1.2 同步调用异步解决方案（最新Abp创建的模板项目已经去掉该同步方法，所以可以通过下面这种方式获取用户列表）
            //var userList = AsyncHelper.RunSync(() => _userAppService.GetUsersAsync());

            //1.3 缓存版本
            //var userList = _cacheManager.GetCache("ControllerCache").Get("AllUsers", () => _userAppService.GetUsers());

            //1.4 转换为泛型版本
            //var userList = _cacheManager.GetCache("ControllerCache").AsTyped<string, ListResultDto<UserListDto>>().Get("AllUsers", () => _userAppService.GetUsers());

            //1.5 泛型缓存版本
            //var userList = _cacheManager.GetCache<string, ListResultDto<UserListDto>>("ControllerCache").Get("AllUsers", () => _userAppService.GetUsers());

            //ViewBag.AssignedPersonId = new SelectList(userList.Items, "Id", "Name");
            return PartialView("_CreateTaskPartial");
        }

        /// <summary>
        /// 获取创建任务分部视图（子视图）
        /// 该方法使用[OutputCache]进行缓存，缓存过期时间为2mins
        /// </summary>
        /// <returns></returns>
        //[ChildActionOnly]
        //[OutputCache(Duration = 1200, VaryByParam = "none")]
        public PartialViewResult Create()
        {
            //var userList = _userAppService.GetUsers();
            //ViewBag.AssignedPersonId = new SelectList(userList.Items, "Id", "Name");
            return PartialView("_CreateTask");
        }

        // POST: Tasks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSimpleTaskInput task)
        {
            var id = _taskAppService.CreateTask(task);

            var input = new GetSimpleTasksInput();
            var output = _taskAppService.GetTasks(input);

            return PartialView("_List", output.Tasks);
        }

        // GET: Tasks/Edit/5

        public PartialViewResult Edit(int id)
        {
            var task = _taskAppService.GetTaskById(id);

            var updateTaskDto = Mapper.Map<UpdateSimpleTaskInput>(task);

            //var userList = _userAppService.GetUsers();
            //ViewBag.AssignedPersonId = new SelectList(userList.Items, "Id", "Name", updateTaskDto.AssignedPersonId);

            return PartialView("_EditTask", updateTaskDto);
        }

        // POST: Tasks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateSimpleTaskInput updateTaskDto)
        {
            _taskAppService.UpdateTask(updateTaskDto);

            var input = new GetSimpleTasksInput();
            var output = _taskAppService.GetTasks(input);

            return PartialView("_List", output.Tasks);
        }

        public ActionResult NotifyUser()
        {
            //_notificationAppService.NotificationUsersWhoHaveOpenTask();
            return new EmptyResult();
        }
    }
}