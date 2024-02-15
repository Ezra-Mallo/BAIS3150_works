using System;

namespace emallo1BAIS3150CodeSample.Domain
{
    public class Student
    {
        private string _studentID = "";
        private string _firstName = string.Empty;

        public string StudentID
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

        public string Email { get; set; } = string.Empty;

    }
}
