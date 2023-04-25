using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EvArkadasim.Data;
using Volo.Abp.DependencyInjection;

namespace EvArkadasim.EntityFrameworkCore
{
    public class EntityFrameworkCoreEvArkadasimDbSchemaMigrator
        : IEvArkadasimDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreEvArkadasimDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the EvArkadasimDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<EvArkadasimDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
