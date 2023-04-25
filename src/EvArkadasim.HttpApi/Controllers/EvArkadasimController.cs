using EvArkadasim.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EvArkadasim.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class EvArkadasimController : AbpController
    {
        protected EvArkadasimController()
        {
            LocalizationResource = typeof(EvArkadasimResource);
        }
    }
}