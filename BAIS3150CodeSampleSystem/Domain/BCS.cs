using BAIS3150CodeSampleSystem.TechnicalServices;
using System;

namespace BAIS3150CodeSampleSystem.Domain
{
    public class BCS
    {
        public bool EnrollStudent(Student acceptedStudent, string programCode)
        {
            bool Confirmation;
            Students StudentManager = new();

            Confirmation = StudentManager.AddStudent(acceptedStudent, programCode);

            return Confirmation;
        }

    }
}
