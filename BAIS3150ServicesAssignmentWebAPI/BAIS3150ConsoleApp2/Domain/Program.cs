using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAIS3150ConsoleApp2.TechnicalServices;

namespace BAIS3150ConsoleApp2.Domain
{
    internal class Program
    {

        private string _programCode = string.Empty;
        private string _description = string.Empty;
        private  List<Student> _enrolledStudents = new();        // or new List<Student>();

        public string ProgramCode
        {
            get{return _programCode; }
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
