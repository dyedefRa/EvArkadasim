using Microsoft.AspNetCore.Authorization;

namespace EvArkadasim.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : EvArkadasimPageModel
    {
        public void OnGet()
        {
        }
    }
}