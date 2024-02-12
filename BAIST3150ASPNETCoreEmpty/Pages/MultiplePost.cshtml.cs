using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIST3150ASPNETCoreEmpty.Pages
{
    public class MultiplePostModel : PageModel
    {
        public string Message { get; set; } = string.Empty;


        [BindProperty]
        public string FirstInputField { get; set; } = string.Empty;

        [BindProperty]
        public string SecondInputField {  get; set; } = string.Empty;

        [BindProperty]
        public string Submit {  get; set; } = string.Empty;     
 

        public void OnGet()   //initial
        {
            Message = "***OnGet ***";
        }
        public void OnPost() //submit
        {
            switch (Submit)
            {
                case "First":
                    Message = "*** OnPost*** ---> First";
                    break;
                case "Second":
                    Message = "*** OnPost*** ---> Second";
                    break;
            }
        }
    }
}
