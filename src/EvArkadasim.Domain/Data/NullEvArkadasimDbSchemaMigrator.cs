using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace EvArkadasim.Data
{
    /* This is used if database provider does't define
     * IEvArkadasimDbSchemaMigrator implementation.
     */
    public class NullEvArkadasimDbSchemaMigrator : IEvArkadasimDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}