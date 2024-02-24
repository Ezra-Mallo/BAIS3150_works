namespace BAIS3150CodeSampleSystem.Domain
{
    public class Student
    {
        private string _studentID = string.Empty;
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;

        public string StudentID
        {
            get { return _studentID; }
            set { _studentID = value; }
        }

        //public string StudentID { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

    }
}
