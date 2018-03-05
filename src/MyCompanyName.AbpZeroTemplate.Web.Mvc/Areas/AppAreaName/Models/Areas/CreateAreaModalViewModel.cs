using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Areas
{
    public class CreateAreaModalViewModel
    {
        public long? ParentAreaId { get; set; }

        public CreateAreaModalViewModel(long? parentAreaId)
        {
            ParentAreaId = parentAreaId;
        }
    }
}
