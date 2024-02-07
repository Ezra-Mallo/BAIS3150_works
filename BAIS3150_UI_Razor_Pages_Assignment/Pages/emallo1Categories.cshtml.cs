using BAIS3150_UI_Razor_Pages_Assignment.Domain;
using BAIS3150_UI_Razor_Pages_Assignment.TechnicalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BAIS3150_UI_Razor_Pages_Assignment.Pages
{
    public class emallo1CategoriesModel : PageModel
    {

        public List<Category> categories { get; set; } = new();
        public void OnGet()
        {
            CategoryHandler CategoryDirector = new();
            categories = CategoryDirector.GetCategories();
            
        }
    }
}
