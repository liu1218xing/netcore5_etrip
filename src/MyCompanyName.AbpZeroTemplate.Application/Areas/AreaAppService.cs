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

        public async Task CreateOrUpdateArea(CreateOrUpdateAreaDto input)
        {
            if (!input.AreaEdit.Id.HasValue)
            {
                await CreateAreaAsync(input);
            }
            else
            {
                await UpdateAreaAsync(input);
            }
        }
        public async Task UpdateAreaAsync(CreateOrUpdateAreaDto input)
        {
            
            var areainput = new Area() { Id = input.AreaEdit.Id.Value, AreaId = input.AreaEdit.AreaId, AreaName = input.AreaEdit.AreaName, AreaDescription = input.AreaEdit.AreaDescription, TenantId = AbpSession.TenantId };
            
            await _areaManager.UpdateAreaAsync(areainput);
        }
        public async Task CreateAreaAsync(CreateOrUpdateAreaDto input)
        {
            var areainput = new Area() { AreaId = input.AreaEdit.AreaId,AreaName =input.AreaEdit.AreaName,AreaDescription = input.AreaEdit.AreaDescription,TenantId= AbpSession.TenantId};
            //var area = ObjectMapper.Map<Area>(input);
            //var organizationUnit = new Area(input.AreaId,inpu);
            //Logger.Info("Creating a new area with description: " + input.AreaEdit.AreaId+input.ToString());

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
        public async Task<GetAreaForEditOutput> GetAreaForEdit(NullableIdDto input)
        {
            AreaListDto AreaEditDto;

            if (input.Id.HasValue) 
            {
                var AreaDto = await _areaManager.GetAreaAsync(input.Id.Value);
                AreaEditDto = ObjectMapper.Map<AreaListDto>(AreaDto);
            }
            else
            {
                AreaEditDto = new AreaListDto();
            }

            return new GetAreaForEditOutput
            {
                AreaEdit = AreaEditDto,
                
            };
        }

        
    }
}
