using System;
using Microsoft.Data.SqlClient;
using System.Data;
using emallo1BAIS3150CodeSample.Domain;
using emallo1BAIS3150CodeSample.Pages;
using Azure.Messaging;

namespace emallo1BAIS3150CodeSample.TechnicalServices
{
    public class Programs
    {
        public bool AddProgram(string programCode, string description)
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
                CommandText = "AddProgram"
            };

            //Parameter
            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = description
            };
            MyCommand.Parameters.Add(MyParameter);


            MyCommand.ExecuteNonQuery();
            MyDataSource.Close();
            Success = true;
            return Success;

        }

        public Domain.Program GetProgram(string programCode)
        {

            //connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //Command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };

            //Parameter
            SqlParameter MyParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = programCode
            };

            MyCommand.Parameters.Add(MyParameter);



            Domain.Program ActiveProgram = new();
            ActiveProgram.ProgramCode = programCode;
            ActiveProgram.Description = (string)MyCommand.ExecuteScalar();

            List<Student> EnrolledStudents;

            Students StudentManager = new();
            EnrolledStudents = StudentManager.GetStudents(programCode);
            ActiveProgram.EnrolledStudents.AddRange(EnrolledStudents);



            return ActiveProgram;
        }
    }
}
