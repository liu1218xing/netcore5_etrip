using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Areas
{
    public class Area : FullAuditedEntity, IMayHaveTenant
    {
        [Required]
        public string AreaId { get; set; }
        [Required]
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public long? ParentAreaId { get; set; }
        public int? TenantId { get; set; }
    }
}
