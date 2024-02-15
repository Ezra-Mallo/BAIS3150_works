using System;
using System.Data;
using emallo1BAIS3150CodeSample.TechnicalServices;



namespace emallo1BAIS3150CodeSample.Domain
{
    public class Program
    {
        private string _programCode = string.Empty;
        private string _description = string.Empty;
        private List<Student> _enrolledStudents = new();        // or new List<Student>();

        public string ProgramCode
        {
            get { return _programCode; }
            set { _programCode = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public List<Student> EnrolledStudents
        {
            get { return _enrolledStudents; }
        }
    }
}
