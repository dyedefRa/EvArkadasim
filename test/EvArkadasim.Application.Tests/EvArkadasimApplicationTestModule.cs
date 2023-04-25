using Volo.Abp.Modularity;

namespace EvArkadasim
{
    [DependsOn(
        typeof(EvArkadasimApplicationModule),
        typeof(EvArkadasimDomainTestModule)
        )]
    public class EvArkadasimApplicationTestModule : AbpModule
    {

    }
}