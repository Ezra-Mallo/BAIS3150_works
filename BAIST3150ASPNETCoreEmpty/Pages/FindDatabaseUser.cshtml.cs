using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIST3150ASPNETCoreEmpty.Domain;

namespace BAIST3150ASPNETCoreEmpty.Pages
{
    public class FindDatabaseUserModel : PageModel
    {
        public required DatabaseUser CurrentDatabaseUser {  get; set; }

        public void OnGet()
        {
            BCS RequestDirector = new();
            CurrentDatabaseUser = RequestDirector.FindDatabaseUser();
        }
    }
}
