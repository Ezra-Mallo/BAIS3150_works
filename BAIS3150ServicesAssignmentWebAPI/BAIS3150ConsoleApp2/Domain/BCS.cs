using BAIS3150ConsoleApp2.TechnicalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAIS3150ConsoleApp2.Domain
{
    internal class BCS
    {
        public bool EnrollStudent(Student acceptedStudent, string programCode)
        {
            bool Confirmation;
            Students StudentManager = new();

            Confirmation = StudentManager.AddStudent(acceptedStudent, programCode);

            return Confirmation;
        }
        public bool CreateProgram(string programCode, string description)
        {
            bool Confirmation;
            Programs  ProgramManager = new();

            Confirmation = ProgramManager.AddProgram(programCode,description);

            return Confirmation;
        }

        public Student FindStudent(string studentID)
        {
            Students StudentManager = new();
            Student Enrolledstudent = StudentManager.GetStudent(studentID);  //student = student getter/Setter construct
            return Enrolledstudent;
        }

        public bool RemoveStudent(string studentID)
        {
            bool Success = false;

            Students StudentManager = new();
            Success = StudentManager.DeleteStudent(studentID);            
            return Success;
        }
        public Domain.Program FindProgram(string programCode)
        {
            Programs ProgramManager = new();
            Domain.Program ActiveProgram= ProgramManager.GetProgram(programCode);  // getter/Setter construct
            return ActiveProgram;
        }

        public bool ModifyStudent(Student enrolledStudent)
        {
           bool  Confirmation= false;

            Students StudentManager = new();
            Confirmation = StudentManager.UpdateStudent(enrolledStudent);  // getter/Setter construct
            return Confirmation;
        }
    }
}
