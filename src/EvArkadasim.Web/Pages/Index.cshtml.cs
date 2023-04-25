using Microsoft.AspNetCore.Mvc;

namespace EvArkadasim.Web.Pages
{
    public class IndexModel : EvArkadasimPageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("~/Home/Index");
        }
    }
}