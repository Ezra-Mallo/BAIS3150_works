using emallo1BAIS3150CodeSample.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace emallo1BAIS3150CodeSample.Pages
{
    public class FindStudentModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        public bool MessageResponse { get; set; } 

        [BindProperty]
        [Required]
        public string StudentID { get; set; } = string.Empty;
        public Student EnrolledStudent { get; set; } = new();
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {

                BCS RequestDirector = new();
                EnrolledStudent = RequestDirector.FindStudent(StudentID);
                if (EnrolledStudent != null)
                {
                    MessageResponse = true;
                    Message = "Below are the details of the student.";
                }
                else
                {
                    MessageResponse = false;
                    Message = "Records does not exist.";
                }
            }
        }
    }
}
