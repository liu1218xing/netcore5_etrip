using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq.Dynamic.Core;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Abp.Web.Models;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
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
            await CheckAreaIdIfAlreadyExists(input.AreaEdit.AreaId, input.AreaEdit.Id);
            await CheckAreaNameIfAlreadyExists(input.AreaEdit.AreaName, input.AreaEdit.Id);
            await _areaManager.UpdateAreaAsync(areainput);
        }
        public async Task CreateAreaAsync(CreateOrUpdateAreaDto input)
        {
            var areainput = new Area() { AreaId = input.AreaEdit.AreaId,AreaName =input.AreaEdit.AreaName,AreaDescription = input.AreaEdit.AreaDescription,TenantId= AbpSession.TenantId};
            //var area = ObjectMapper.Map<Area>(input);
            //var organizationUnit = new Area(input.AreaId,inpu);
            //Logger.Info("Creating a new area with description: " + input.AreaEdit.AreaId+input.ToString());
            await CheckAreaIdIfAlreadyExists(input.AreaEdit.AreaId);
            await CheckAreaNameIfAlreadyExists(input.AreaEdit.AreaName);
            await _areaManager.CreateAreaAsync(areainput);
        }

        public async Task DeleteArea(EntityDto input)
        {
            var area = await _areaManager.GetAreaAsync(input.Id);
            await _areaManager.DeleteAreaAsync(area);
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
            AreaEditDto AreaEditDto;

            if (input.Id.HasValue) 
            {
                var AreaDto = await _areaManager.GetAreaAsync(input.Id.Value);
                AreaEditDto = ObjectMapper.Map<AreaEditDto>(AreaDto);
            }
            else
            {
                AreaEditDto = new AreaEditDto();
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

        private async Task CheckAreaIdIfAlreadyExists(string areaid, int? expectedId = null)
        {
            //var existingAreas = _areaRepository.GetAll().WhereIf(!areaid.IsNullOrWhiteSpace(),a=>a.AreaId ==areaid);
            
            var existingArea = (await _areaManager.GetAllAsync())
                    .FirstOrDefault(a => a.AreaId == areaid);
            
            if (existingArea == null)
            {
                return;
            }
            
            if (expectedId != null && existingArea.Id == expectedId.Value)
            {
                return;
            }

            throw new UserFriendlyException(L("ThisAreaIdAlreadyExists"));
        }

        private async Task CheckAreaNameIfAlreadyExists(string areaName, int? expectedId = null)
        {

            var existingArea = (await _areaManager.GetAllAsync())
                    .FirstOrDefault(a => a.AreaName == areaName);

            if (existingArea == null)
            {
                return;
            }

            if (expectedId != null && existingArea.Id == expectedId.Value)
            {
                return;
            }

            throw new UserFriendlyException(L("ThisAreaNameAlreadyExists"));
        }

        public async Task<PagedResultDto<AreaListDto>> GetAreasFilter(GetAreaInput input)
        {
            var query = _areaRepository.GetAll().
                WhereIf(
                input.Filter.IsNullOrWhiteSpace(),
                a => a.AreaId.Contains(input.Filter) ||
                a.AreaName.Contains(input.Filter) ||
                a.AreaDescription.Contains(input.Filter)
                );
            var areas = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
            var areaCount = await query.CountAsync();
            var areaListDtos = ObjectMapper.Map<List<AreaListDto>>(areas);
            return new PagedResultDto<AreaListDto>(
                areaCount,
                areaListDtos
                );
        }
        private IQueryable<AreaListDto> CreateAreaListQuery(GetAreaInput input)
        {
            var query = from area in _areaRepository.GetAll()
                        select new AreaListDto { AreaId = area.AreaId,AreaName =area.AreaName };
            query.WhereIf(input.Filter.IsNullOrWhiteSpace(), a => a.AreaId.Contains(input.Filter) ||
             a.AreaName.Contains(input.Filter) ||
             a.AreaDescription.Contains(input.Filter));
            return query; 

        }
    }
}
