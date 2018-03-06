using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Castle.Core.Logging;
using MyCompanyName.AbpZeroTemplate.Areas.Dto;

namespace MyCompanyName.AbpZeroTemplate.Areas
{
    public class AreaAppService : AbpZeroTemplateAppServiceBase, IAreaAppService
    {
        public ILogger Logger { get; set; }
        private readonly IAreaManager _areaManager;
        public AreaAppService(IAreaManager areaManager)
        {
            _areaManager = areaManager;
        }
        

        public async Task CreateOrUpdateArea(CreateAreaInput input)
        {
            var areainput = new Area() { AreaId = input.AreaId,AreaName =input.AreaName,AreaDescription = input.AreaDescription};
            //var area = ObjectMapper.Map<Area>(input);
            //var organizationUnit = new Area(input.AreaId,inpu);
            Logger.Info("Creating a new area with description: " + input.AreaId+input.ToString());

            await _areaManager.CreateAreaAsync(areainput);
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
        public async Task<ListResultDto<AreaListDto>> GetAllAreas()
        {
            var editions = await _areaManager.GetAllAsync();
            return new ListResultDto<AreaListDto>(
                ObjectMapper.Map<List<AreaListDto>>(editions)
                );
        }
    }
}
