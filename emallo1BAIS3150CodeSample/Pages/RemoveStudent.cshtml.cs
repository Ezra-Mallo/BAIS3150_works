using Microsoft.AspNetCore.Mvc;
using emallo1BAIS3150CodeSample.TechnicalServices;

using Microsoft.AspNetCore.Mvc.RazorPages;
using emallo1BAIS3150CodeSample.Domain;
using System.ComponentModel.DataAnnotations;

namespace emallo1BAIS3150CodeSample.Pages
{
    public class RemoveStudentModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        
        
        [BindProperty]
        [Required(ErrorMessage = "Student ID must not be blank.")]
        public string StudentID { get; set; } = string.Empty;
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                bool Confirmation;
                Student EnrolledStudent = new();
                BCS RequestDirector = new();
                EnrolledStudent = RequestDirector.FindStudent(StudentID);
                if (EnrolledStudent != null)
                {
                    Confirmation = RequestDirector.RemoveStudent(StudentID);
                    if (Confirmation = true)
                        Message = "Record of Student ID " + StudentID + " has been deleted succesfully.";
                    else
                        Message = "Record of Student ID " + StudentID + " was not deleted.";
                }
                else
                    Message = "Record of Student ID " + StudentID + " does not exist.";
            }
        }

    }
}
