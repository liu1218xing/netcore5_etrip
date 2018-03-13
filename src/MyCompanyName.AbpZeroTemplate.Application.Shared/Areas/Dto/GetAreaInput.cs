using Abp.Extensions;
using Abp.Runtime.Validation;
using MyCompanyName.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Areas.Dto
{
   public class GetAreaInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }
        

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "AreaId DESC";
            }
        }
    }
}
