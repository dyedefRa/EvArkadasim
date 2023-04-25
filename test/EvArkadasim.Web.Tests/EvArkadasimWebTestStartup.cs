using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace EvArkadasim
{
    public class EvArkadasimWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<EvArkadasimWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}