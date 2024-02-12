using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150ASPNETCoreEmpty.Pages
{
    public class ValidationClientServerModel : PageModel
    {
        public string Message { get; set; } = string.Empty;

        [BindProperty]
        public string InputField { get; set; } = string.Empty;

        public void OnGet()
        {
            Message = "*** OnGet ***";
        }

        public void OnPost()
        {
            //validate - Server
            if (InputField ==null || !(InputField.Length > 0 && InputField.Length <=5))
            {
                ModelState.AddModelError("InputField", "Input field is required and must contain up to 5 characters.");
            }

            //check ModelState
            if (ModelState.IsValid)
            {
                Message = "*** OnPost *** - Valid";
            }
            else
            {
                Message = "*** OnPost *** - Not Valid";
            }

            
        }
    }
}
