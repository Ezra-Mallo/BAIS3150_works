using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150ASPNETCoreEmpty.Pages
{
    public class TestPageModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        [BindProperty]
        public string Field { get; set; } = string.Empty;

        public void OnGet()  // initial
        {
            Message = "*** OnGet ***";
        }
        public void OnPost()  // submit
        {
            Message = "*** OnPost ***";
        }
    }
}
