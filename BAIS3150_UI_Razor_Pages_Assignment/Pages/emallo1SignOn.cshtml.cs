using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BAIS3150_UI_Razor_Pages_Assignment.Pages
{
    public class emallo1SignOnModel : PageModel
    {

        [BindProperty]
        [Required(ErrorMessage = "User ID is required.")]
        [StringLength(8, ErrorMessage = "User ID must be at least 8 characters.", MinimumLength = 8)]
        [RegularExpression(@"^[A-Z]{4}\d{4}$", ErrorMessage = "User ID must follow this format ABCD1234.")]
        public string UserID { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = string.Empty;
        
        public void OnGet()
        {
        }
    }
}
