using EvArkadasim.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using System.Net;

namespace EvArkadasim.Web.Pages.Error
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ErrorModel Error { get; set; } = new ErrorModel();
        private readonly IStringLocalizer<EvArkadasimResource> _L;

        public IndexModel(IStringLocalizer<EvArkadasimResource> L)
        {
            _L = L;
        }
        public void OnGet(int httpStatusCode)
        {
            if (httpStatusCode == 0 || httpStatusCode == (int)HttpStatusCode.NotFound) //0 || 404
            {
                Error.Message = _L["NotFoundPage"];
                Error.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (httpStatusCode == (int)HttpStatusCode.Unauthorized) //401 YETKISI YOK
            {
                Error.Message = _L["UnauthorizedPage"];
                Error.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                Error.Message = _L["UnexpectedErrorPage"];
                Error.StatusCode = 0;
            }
        }

        public class ErrorModel
        {
            public string Message { get; set; }
            public int StatusCode { get; set; }
        }
    }
}
