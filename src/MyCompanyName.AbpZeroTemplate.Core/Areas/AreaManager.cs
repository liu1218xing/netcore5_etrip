using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Areas
{
    public class AreaManager : AbpZeroTemplateDomainServiceBase, IAreaManager
    {
        private readonly IRepository<Area> _areaRepository;

        public AreaManager(IRepository<Area> areaRepository)
        {
            _areaRepository = areaRepository;
        }
        [UnitOfWork]
         public async Task CreateAreaAsync(Area area)
        {
            await _areaRepository.InsertAsync(area);
            await CurrentUnitOfWork.SaveChangesAsync();
            
        }
        [UnitOfWork]
        public async Task<List<Area>> GetAllAsync()
        {
            return await _areaRepository.GetAllListAsync();
        }
        //public async Task<Area> GetSingleAreaAsync(Area area)
        //{
        //    if (area.AreaId.HasValue)
        //    {

        //    }
        //}
        [UnitOfWork]
        public async Task UpdateAreaAsync(Area area)
        {
            var getarea = await _areaRepository.GetAsync(area.Id);

            //ObjectMapper.Map(area, getarea);
            getarea.AreaId = area.AreaId;
            getarea.AreaName = area.AreaName;
            getarea.AreaDescription = area.AreaDescription;
            await _areaRepository.UpdateAsync(getarea);
            await CurrentUnitOfWork.SaveChangesAsync();
            
        }
        [UnitOfWork]
        public async Task DeleteAreaAsync(Area area)
        {
            var getarea = await _areaRepository.GetAsync(area.Id);
            
            
            await _areaRepository.DeleteAsync(getarea);
            await CurrentUnitOfWork.SaveChangesAsync();
        }
        [UnitOfWork]
        public async Task<Area> GetAreaAsync(int id)
        {
            return await _areaRepository.GetAsync(id); 
        }

        public async Task<Area> GetSingleAreaAsync(Area area)
        {
            Expression<Func<Area, bool>> predicate = null;
            predicate = f => f.AreaId == area.AreaId || f.AreaName == area.AreaName;
            return await _areaRepository.SingleAsync(predicate);
            
        }
    }
}
