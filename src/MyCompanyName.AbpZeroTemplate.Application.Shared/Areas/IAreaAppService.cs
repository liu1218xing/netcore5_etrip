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
        Task CreateOrUpdateArea(CreateOrUpdateAreaDto input);

        Task<ListResultDto<AreaListDto>> GetAreas();
        Task<PagedResultDto<AreaListDto>> GetAreasFilter(GetAreaInput input);

        Task<ListResultDto<AreaListDto>> GetAllAreas();
        Task CreateAreaAsync(CreateOrUpdateAreaDto input);
        Task UpdateAreaAsync(CreateOrUpdateAreaDto input);
        //Task CreateOrUpdateArea(CreateAreaInput input);
        Task<bool> GetValidAreaIdOrName(GetAreaInput input);
        Task<bool> GetValidateAreaId(GetAreaInputS input);
        Task<string> GetValidateAreaIdString(GetAreaInputS input);
        Task DeleteArea(EntityDto input);
        Task<GetAreaForEditOutput> GetAreaForEdit(NullableIdDto input);

    }
}
