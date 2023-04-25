using EvArkadasim.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace EvArkadasim.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(EvArkadasimEntityFrameworkCoreModule),
        typeof(EvArkadasimApplicationContractsModule)
        )]
    public class EvArkadasimDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
