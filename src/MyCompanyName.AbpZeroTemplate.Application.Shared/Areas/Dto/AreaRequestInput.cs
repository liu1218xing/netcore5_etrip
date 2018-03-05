using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Areas.Dto
{
    public class AreaRequestInput
    {
        public long AreaId { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public long? ParentAreaId { get; set; }
    }
}
