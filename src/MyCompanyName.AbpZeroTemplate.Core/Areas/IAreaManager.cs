using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Services;

namespace MyCompanyName.AbpZeroTemplate.Areas
{
    public interface IAreaManager : IDomainService
    {
        Task CreateAreaAsync(Area area);

        Task UpdateAreaAsync(Area area);
        Task DeleteAreaAsync(Area area);
        Task<List<Area>> GetAllAsync();
    }
}
