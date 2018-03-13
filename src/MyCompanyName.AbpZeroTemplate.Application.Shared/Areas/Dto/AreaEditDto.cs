using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Areas.Dto
{
    public class AreaEditDto
    {
        public int? Id { get; set; }
        [Required]
        public string AreaId { get; set; }
        [Required]
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public long? ParentAreaId { get; set; }
    }
}
