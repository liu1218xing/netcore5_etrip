using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Areas.Dto
{
    public class AreaListDto 
    {
        public int? Id { get; set; }
        [Required]
        public long AreaId { get; set; }
        [Required]
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public long? ParentAreaId { get; set; }
    }
}
