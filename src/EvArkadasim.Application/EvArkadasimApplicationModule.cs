﻿using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace EvArkadasim
{
    [DependsOn(
        typeof(EvArkadasimDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(EvArkadasimApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule)
        )]

    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class EvArkadasimApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<EvArkadasimApplicationModule>();
            });
        }
    }
}
