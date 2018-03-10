using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCompanyName.AbpZeroTemplate.Areas;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Areas;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;

namespace MyCompanyName.AbpZeroTemplate.Web.Mvc.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Areas)]
    public class AreasController :  AbpZeroTemplateControllerBase
    {
        private readonly IAreaAppService _areaAppService;
        public AreasController(IAreaAppService areaAppService)
        {
            _areaAppService = areaAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public PartialViewResult CreateModal(long? parentAreaId)
        //{
        //    return PartialView("_CreateModal", new CreateOrEditAreaModalViewModel());
        //}
        [AbpMvcAuthorize(AppPermissions.Pages_Administration_Areas_Create)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            var output = await _areaAppService.GetAreaForEdit(new NullableIdDto { Id = id });
            
            var viewModel = new CreateOrEditAreaModalViewModel(output);

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}