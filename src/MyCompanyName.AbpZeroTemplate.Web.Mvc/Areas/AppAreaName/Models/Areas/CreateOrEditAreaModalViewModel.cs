using Abp.AutoMapper;
using MyCompanyName.AbpZeroTemplate.Areas.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Areas
{
    [AutoMapFrom(typeof(GetAreaForEditOutput))]
    public class CreateOrEditAreaModalViewModel : GetAreaForEditOutput
    {
        public bool IsEditMode
        {
            get { return AreaEdit.Id.HasValue; }
        }

        public CreateOrEditAreaModalViewModel(GetAreaForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}
