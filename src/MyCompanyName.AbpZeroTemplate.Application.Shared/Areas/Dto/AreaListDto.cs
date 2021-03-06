﻿using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Areas.Dto
{
    public class AreaListDto : EntityDto, IHasCreationTime
    {
        
        [Required]
        public string AreaId { get; set; }
        [Required]
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public long? ParentAreaId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
