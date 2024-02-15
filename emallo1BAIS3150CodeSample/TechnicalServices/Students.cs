using System;
using System.Data;
using emallo1BAIS3150CodeSample.Domain;
using Microsoft.Data.SqlClient;

namespace emallo1BAIS3150CodeSample.TechnicalServices
{
    public class Students
    {
        public bool AddStudent(Student acceptedStudent, string programCode)
        {
            bool Success = false;

            //connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();

            //command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddStudent"
            };

            //Parameter
            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.StudentID
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.FirstName
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.LastName
            };
            MyCommand.Parameters.Add(MyParameter);


            MyParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = acceptedStudent.Email
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            MyCommand.Parameters.Add(MyParameter);

            MyCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;
        }


        public Student GetStudent(string studentID)
        {
            //Connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudent"
            };

            //Parameter
            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = studentID
            };
            MyCommand.Parameters.Add(MyParameter);


            //DataReader
            SqlDataReader MyDataReader;
            MyDataReader = MyCommand.ExecuteReader();
            Student Enrolledstudent = null;

            if (MyDataReader.HasRows)
            {
                MyDataReader.Read(); // Move to the first row

                Enrolledstudent = new()
                {
                    StudentID = MyDataReader["StudentID"].ToString(),
                    FirstName = MyDataReader["FirstName"].ToString(),
                    LastName = MyDataReader["LastName"].ToString(),
                    Email = MyDataReader["Email"].ToString()
                };
            };
            MyDataReader.Close();
            MyDataSource.Close();
            return Enrolledstudent;

        }

        public bool UpdateStudent(Student enrolledStudent)
        {
            bool Success;
            Success = false;

            //connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();


            //command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateStudent"
            };

            //Parameter
            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.StudentID
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.FirstName
            };
            MyCommand.Parameters.Add(MyParameter);


            MyParameter = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.LastName
            };
            MyCommand.Parameters.Add(MyParameter);


            MyParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = enrolledStudent.Email
            };
            MyCommand.Parameters.Add(MyParameter);



            MyCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;
        }
        public bool DeleteStudent(string studentID)
        {
            bool Success = false;


            //sqlconnection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();


            //Command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteStudent"
            };

            //Parameter
            SqlParameter MyParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = studentID
            };

            MyCommand.Parameters.Add(MyParameter);
            MyCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;
        }


        public List<Student> GetStudents(string programCode)
        {
            //Conneciton
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //Command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudentByProgram"
            };

            //Paratmeter
            SqlParameter MyParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            MyCommand.Parameters.Add(MyParameter);

            //DataReader
            SqlDataReader MyDataReader = MyCommand.ExecuteReader();
            List<Student> EnrolledStudents = new();


            if (MyDataReader.HasRows)
            {
                while (MyDataReader.Read())
                {
                    Student EnrolledStudent = new()
                    {
                        StudentID = (string)MyDataReader["StudentID"],
                        FirstName = (string)MyDataReader["FirstName"],
                        LastName = (string)MyDataReader["LastName"],
                        Email = (string)MyDataReader["Email"]

                    };
                    EnrolledStudents.Add(EnrolledStudent);
                }
            }


            MyDataReader.Close();
            MyDataSource.Close();

            return EnrolledStudents;
        }
    }
}
