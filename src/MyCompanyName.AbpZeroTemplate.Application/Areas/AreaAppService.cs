using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Areas.Dto;

namespace MyCompanyName.AbpZeroTemplate.Areas
{
    public class AreaAppService : AbpZeroTemplateAppServiceBase, IAreaAppService
    {
        private readonly IAreaManager _areaManager;
        public AreaAppService(IAreaManager areaManager)
        {
            _areaManager = areaManager;
        }
        public async Task CreateOrUpdateArea(CreateAreaInput input)
        {
            var area = ObjectMapper.Map<Area>(input);
            //var organizationUnit = new Area(input.AreaId,inpu);

            await _areaManager.CreateAreaAsync(area);
        }

        public Task DeleteEdition(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<AreaListDto>> GetAreas()
        {
            var editions =await _areaManager.GetAllAsync();
            return new ListResultDto<AreaListDto>(
                ObjectMapper.Map<List<AreaListDto>>(editions)
                );
        }
    }
}
