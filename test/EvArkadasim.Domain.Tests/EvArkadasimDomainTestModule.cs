using EvArkadasim.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EvArkadasim
{
    [DependsOn(
        typeof(EvArkadasimEntityFrameworkCoreTestModule)
        )]
    public class EvArkadasimDomainTestModule : AbpModule
    {

    }
}