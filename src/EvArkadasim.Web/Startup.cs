using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EvArkadasim.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<EvArkadasimWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}

//mybreadcrumbs > deki Üye ol yada Giriş yap yazılarını kaldır? V  (_Navigation de var )

// Mesaj ve proifl için svg üret fontawesome.
