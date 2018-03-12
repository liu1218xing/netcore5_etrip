using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Web.Models;
using Castle.Core.Logging;
using MyCompanyName.AbpZeroTemplate.Areas.Dto;

namespace MyCompanyName.AbpZeroTemplate.Areas
{
    public class AreaAppService : AbpZeroTemplateAppServiceBase, IAreaAppService
    {
        public ILogger Logger { get; set; }
        private readonly IAreaManager _areaManager;
        private readonly IRepository<Area,int> _areaRepository;
        public AreaAppService(IAreaManager areaManager, IRepository<Area, int> areaRepository)
        {
            _areaManager = areaManager;
            _areaRepository = areaRepository;
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

        public async Task<bool> GetValidAreaIdOrName(GetAreaInput input)
        {

            //Expression<Func<Area, bool>> areaExpress = null;
            //areaExpress = f => f.AreaId == input.AreaEdit.AreaId || f.AreaName == input.AreaEdit.AreaName;
            //var area = await _areaRepository.SingleAsync(areaExpress);
            var area = await _areaManager.GetAllAsync();
            //var area = (await _areaManager.GetAllAsync())
            //    .FirstOrDefault(a=>a.AreaId == input.AreaEdit.AreaId || a.AreaName == input.AreaEdit.AreaName);
            if (area != null)
            {
                return false;
            }
            else
            {
                return true;
            }
            //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
            //var AreaDto = await _areaManager.GetSingleAreaAsync(input.Id.Value);
            //throw new NotImplementedException();
        }
        [DontWrapResult]
        public async Task<bool> GetValidateAreaId(GetAreaInputS input)
        {
            //Expression<Func<Area, bool>> areaExpress = null;
            //areaExpress = f => f.AreaId == input.AreaId;
            //var area = await _areaRepository.SingleAsync(areaExpress);
            var areaall = await _areaManager.GetAllAsync();
            if (areaall != null)
            {
                return false;
                //return input.AreaId == area.AreaId ? false : true;
            }
            else
            {
                return false;
            }
            //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
            //var AreaDto = await _areaManager.GetSingleAreaAsync(input.Id.Value);
            //throw new NotImplementedException();
        }
        [DontWrapResult]
        public async Task<string> GetValidateAreaIdString(GetAreaInputS input)
        {
            Expression<Func<Area, bool>> areaExpress = null;
            areaExpress = f => f.AreaId == input.AreaId;
            //var area = await _areaRepository.SingleAsync(areaExpress);
            var areaall = await _areaManager.GetAllAsync();
            if (areaall != null)
            {
                return "false";
                //return input.AreaId == area.AreaId ? false : true;
            }
            else
            {
                return "false";
            }
            //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
            //var AreaDto = await _areaManager.GetSingleAreaAsync(input.Id.Value);
            //throw new NotImplementedException();
        }
    }
}
