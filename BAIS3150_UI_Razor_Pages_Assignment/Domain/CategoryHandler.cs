using BAIS3150_UI_Razor_Pages_Assignment.TechnicalServices;

namespace BAIS3150_UI_Razor_Pages_Assignment.Domain
{
    public class CategoryHandler
    {
        public List<Category> GetCategories()
        {
            Categories CategoryManager = new();
            List<Category> AllCategories = CategoryManager.FindCategories();        

            return AllCategories;
        }
    }
}
