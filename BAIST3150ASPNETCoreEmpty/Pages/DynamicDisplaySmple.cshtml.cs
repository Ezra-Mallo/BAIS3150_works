using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BAIST3150ASPNETCoreEmpty.Domain;

namespace BAIST3150ASPNETCoreEmpty.Pages
{
    public class DynamicDisplaySmpleModel : PageModel
    {
        private List<SampleClass> _sampleObjectCollection = new();
        public List<SampleClass> SampleObjectCollection { 
            get 
            {  
                return _sampleObjectCollection; 
            } 
        }    

        //or
        // public List<SampleClass> SampleObjectCollection {get;} = new();
        public void OnGet()
        {
            SampleClass SampleObject;

            SampleObject = new();
            SampleObject.FirstProperty ="1";
            SampleObject.SecondProperty ="One";
            SampleObjectCollection.Add(SampleObject);

            SampleObject = new()
            {
                FirstProperty = "2",
                SecondProperty = "Two"
            };
            SampleObjectCollection.Add(SampleObject);

            SampleObject = new()
            {
                FirstProperty = "3",
                SecondProperty = "Three"
            };
            SampleObjectCollection.Add(SampleObject);

        }
    }
}
