﻿using Abp.Application.Services;
using MyCompanyName.AbpZeroTemplate.Tenants.Dashboard.Dto;

namespace MyCompanyName.AbpZeroTemplate.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();

        GetDashboardDataOutput GetDashboardData(GetDashboardDataInput input);

        GetSalesSummaryOutput GetSalesSummary(GetSalesSummaryInput input);

        GetWorldMapOutput GetWorldMap(GetWorldMapInput input);

        GetGeneralStatsOutput GetGeneralStats(GetGeneralStatsInput input);
    }
}
