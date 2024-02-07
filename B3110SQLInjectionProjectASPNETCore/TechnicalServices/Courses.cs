﻿using B3110SQLInjectionProjectASPNETCore.Domain;
using Microsoft.Data.SqlClient;
using System.Data;

namespace B3110SQLInjectionProjectASPNETCore.TechnicalServices
{
    public class Courses
    {
        public List<Course> GetCourse(string programCode, string majorCode, string term, int semester)
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
                CommandText = "SQLIGetCourse"
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



            //Parameter
            MyParameter = new()
            {
                ParameterName = "@MajorCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = majorCode
            };
            MyCommand.Parameters.Add(MyParameter);


            //Parameter
            MyParameter = new()
            {
                ParameterName = "@Term",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = term
            };
            MyCommand.Parameters.Add(MyParameter);

            //Parameter
            MyParameter = new()
            {
                ParameterName = "@Semester",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = semester
            };
            MyCommand.Parameters.Add(MyParameter);


            SqlDataReader MyDataReader = MyCommand.ExecuteReader();


            List<Course> CreditCourses = new();
            

            if (MyDataReader.HasRows)
            {
                Course aCourse = new();
                while (MyDataReader.Read())
                {
                    aCourse = new()
                    {
                        CourseCode = (string)MyDataReader["CourseCode"],
                        Description = (string)MyDataReader["Description"],
                        ProgramCode = (string)MyDataReader["ProgramCode"],
                        MajorCode = (string)MyDataReader["MajorCode"],
                        Credit = (int)MyDataReader["Credit"],
                        Term = (string)MyDataReader["Term"],
                        Semester = (int)MyDataReader["Semester"]
                    };
                    CreditCourses.Add(aCourse);
                }


            }
            return CreditCourses;
        }
    }
}
