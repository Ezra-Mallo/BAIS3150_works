using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BAIST3150ASPNETCoreEmpty.Pages
{
    public class ValidationDAAModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        
        [BindProperty]
        [Required]
        [StringLength(5, MinimumLength =1)]        
        public string InputField { get; set; } = string.Empty;

        public void OnGet()
        {
            Message = "*** OnGet ***";
        }
        public void OnPost()
        {
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
