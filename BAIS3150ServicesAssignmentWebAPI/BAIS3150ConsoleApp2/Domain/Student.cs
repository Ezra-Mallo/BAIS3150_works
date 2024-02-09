using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAIS3150ConsoleApp2.Domain
{
    internal class Student
    {

        private string _studentID = "";
        private string _firstName = string.Empty;

        public String StudentID
        {
            get
            {
                return _studentID;
            }
            set
            {
                _studentID = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName { get; set; } = string.Empty;

        public string Email { get;  set;} = string.Empty;

    }
}