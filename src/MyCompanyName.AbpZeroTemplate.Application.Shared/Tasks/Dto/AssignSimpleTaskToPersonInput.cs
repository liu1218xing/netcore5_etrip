using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Tasks.Dto
{
    public class AssignSimpleTaskToPersonInput
    {
        public int TaskId { get; set; }

        public long UserId { get; set; }
    }
}
