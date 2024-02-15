using emallo1BAIS3150CodeSample.Domain;
using emallo1BAIS3150CodeSample.TechnicalServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Web;

namespace emallo1BAIS3150CodeSample.Pages
{
    public class EnrollStudentModel : PageModel
    {
        public string Message { get; set; } = string.Empty;
        public bool MessageResponse { get; set; } = false;

        [BindProperty]
        [Required(ErrorMessage = "Student ID must not be blank.")]
        [StringLength(10, ErrorMessage = "Student ID must not be more than 10 characters.")]
        public string StudentID { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "First Name must not be blank.")]
        [StringLength(25, ErrorMessage = "First Name must not be more than 25 characters.")]
        public string FirstName { get; set; } = string.Empty;
        
        
        [BindProperty]
        [Required(ErrorMessage = "Last Name must not be blank.")]
        [StringLength(25, ErrorMessage = "Last Name must not be more than 25 characters.")]
        public string LastName { get; set; } = string.Empty;

        
        [BindProperty]
        [StringLength(50, ErrorMessage = "Email must not be more than 50 characters.")]
        public string Email { get; set; } = string.Empty;
        

        [BindProperty]
        [Required(ErrorMessage = "Program Code must not be blank.")]
        [StringLength(10, ErrorMessage = "Program Code must not be more than 25 characters.")] 
        public string ProgramCode { get; set; } = string.Empty;
        
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Student AcceptedStudent = new()
                {
                    StudentID = StudentID,
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email
                };

                bool Confirmation; 
                BCS RequestDirector = new();
                Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode);
                if (Confirmation)
                {
                    Message = "Enrolling Student was successful.";
                    MessageResponse = true;
                    ModelState.Clear();
                }
                else
                {
                    Message = "Enrolling Student was not successful.";
                    MessageResponse = false;
                }
                
            }            
        }
    }
}
