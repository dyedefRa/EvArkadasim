using EvArkadasim.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EvArkadasim.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class EvArkadasimPageModel : AbpPageModel
    {
        protected EvArkadasimPageModel()
        {
            LocalizationResourceType = typeof(EvArkadasimResource);
        }
    }
}