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


//Anasayfa 3 dropdows
//Login vs breadcumb yada navigation.

//Tüm imagelere title ve alt ver
//Pagedeki validatetoken ları kontrol et Auto yapma Validatetoken yap ve uygula.