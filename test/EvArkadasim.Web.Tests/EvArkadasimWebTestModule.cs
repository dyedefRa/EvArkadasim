using EvArkadasim.Localization;
using EvArkadasim.Web;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Globalization;
using Volo.Abp.AspNetCore.TestBase;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation.Localization;

namespace EvArkadasim
{
    [DependsOn(
        typeof(AbpAspNetCoreTestBaseModule),
        typeof(EvArkadasimWebModule),
        typeof(EvArkadasimApplicationTestModule)
    )]
    public class EvArkadasimWebTestModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<IMvcBuilder>(builder =>
            {
                builder.PartManager.ApplicationParts.Add(new AssemblyPart(typeof(EvArkadasimWebModule).Assembly));
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalizationServices(context.Services);
            //ConfigureNavigationServices(context.Services);
        }

        private static void ConfigureLocalizationServices(IServiceCollection services)
        {
            var cultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("tr") };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });

            services.Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<EvArkadasimResource>()
                    .AddBaseTypes(
                        typeof(AbpValidationResource),
                        typeof(AbpUiResource)
                    );
            });
        }

        //private static void ConfigureNavigationServices(IServiceCollection services)
        //{
        //    services.Configure<AbpNavigationOptions>(options =>
        //    {
        //        options.MenuContributors.Add(new EvArkadasimMenuContributor());
        //    });
        //}
    }
}
