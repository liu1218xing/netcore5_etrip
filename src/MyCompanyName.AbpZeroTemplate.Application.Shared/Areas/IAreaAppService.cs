using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Areas.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Areas
{
    public interface IAreaAppService : IApplicationService
    {
        Task<ListResultDto<AreaListDto>> GetAreas();

        Task CreateOrUpdateArea(CreateAreaInput input);

        Task DeleteEdition(EntityDto input);
    }
}
