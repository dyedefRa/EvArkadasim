using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace EvArkadasim.Web
{
    [Dependency(ReplaceServices = true)]
    public class EvArkadasimBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "EvArkadasim";
    }
}
