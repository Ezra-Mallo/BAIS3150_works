using System.Data;
using Microsoft.Data.SqlClient;
using System.Runtime.ExceptionServices;
using System.Diagnostics;
using BAIS3150ConsoleApp2.Domain;
using BAIS3150ConsoleApp2.TechnicalServices;



namespace BAIS3150ConsoleApp2
{
    internal class Program
    {


        static void AddProgramExecuteNonQuery()
        {
            Console.WriteLine("AddProgram");

            //Connection to sql
            SqlConnection MyDataSource; // declaration 
            MyDataSource = new(); // Initialisation
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();


            //Command to run on the connection
            SqlCommand MyCommand = new();
            MyCommand.Connection = MyDataSource;
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.CommandText = "AddProgram";

            //Data to send to the Command
            SqlParameter MyParameter;       //declaration
            MyParameter = new()                 //initialization
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "TEST2"
            };

            //adding the parameter to the command that is already connected to datasource
            MyCommand.Parameters.Add(MyParameter);

            //Data to send to the Command
            MyParameter = new()                 //initialization
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "The Secont Test Program"
            };

            //adding the parameter to the command that is already connected to datasource
            MyCommand.Parameters.Add(MyParameter);

            //Executing the Query to commit the data to the Datasource
            MyCommand.ExecuteNonQuery();

            //CLose DB
            MyDataSource.Close();
        }
        static void GetProgramsExecuteReader()
        {
            Console.WriteLine("GetPrograms");

            //Sql Connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();

            //sql command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetPrograms"
            };


            //sql DataReader
            SqlDataReader MyDataReader;
            MyDataReader = MyCommand.ExecuteReader();

            if (MyDataReader.HasRows)
            {
                for (int i = 0; i < MyDataReader.FieldCount; i++)
                {
                    Console.Write(MyDataReader.GetName(i));
                    Console.Write(",");
                }
                Console.WriteLine();
                while (MyDataReader.Read())
                {
                    for (int i = 0; i < MyDataReader.FieldCount; i++)
                    {
                        Console.Write(MyDataReader[i].ToString());
                        Console.Write(",");
                    }
                    Console.WriteLine();
                }
            }

        }
        static void GetProgramExecuteScaler()
        {
            Console.WriteLine("GetProgram for a scaler read");

            //Sql Connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();

            //sql command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetProgram"
            };


            //sql Parameter
            SqlParameter MyParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };

            MyCommand.Parameters.Add(MyParameter);

            Console.WriteLine(MyCommand.ExecuteScalar().ToString());
            MyDataSource.Close();

        }

        static void AddStudent()
        {
            Console.WriteLine("AddStudent");

            //Sql Connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //Sql Command
            SqlCommand MyCommand = new();
            MyCommand.Connection = MyDataSource;
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.CommandText = "AddStudent";



            //Sql Parameter

            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "2005"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Anulika"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Nwachukwu"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Anuli@nait.ca"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyCommand.ExecuteNonQuery();

            MyDataSource.Close();
            Console.WriteLine("Student added succesfully.");




        }

        static void UpdateStudent()
        {
            Console.WriteLine(" UpdateStudent");

            //sql Connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();


            //sql command
            SqlCommand MyCommand = new();
            MyCommand.Connection = MyDataSource;
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.CommandText = "UpdateStudent";


            //Sql Parameter
            SqlParameter MyParameter;

            MyParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "2004"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Anulika"
            };
            MyCommand.Parameters.Add(MyParameter);


            MyParameter = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Nwachukwu"
            };
            MyCommand.Parameters.Add(MyParameter);


            MyParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "anuli1@nait.ca"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };
            MyCommand.Parameters.Add(MyParameter);

            MyCommand.ExecuteNonQuery();

            MyDataSource.Close();


        }

        static void DeleteStudent()
        {
            Console.WriteLine("DeleteStudent");

            //Connectiojn
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

            //Sql Parameter
            SqlParameter MyParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Example2"
            };

            MyCommand.Parameters.Add(MyParameter);
            MyCommand.ExecuteNonQuery();

            MyDataSource.Close();
            
        }

        static void GetStudent()
        {
            Console.WriteLine("GetStudent");

            //connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //command
            SqlCommand ExampleCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudent"  // same name as in the sql
            };

            //Parameter
            SqlParameter ExampleCommandParameter = new()
            {
                ParameterName = "@StudentID",  // same name as in the sql
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "99"
            };

            ExampleCommand.Parameters.Add(ExampleCommandParameter);

            SqlDataReader ExampleDataReader;
            ExampleDataReader = ExampleCommand.ExecuteReader();

            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Columns");
                Console.WriteLine("-------");


                for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                {
                    Console.WriteLine(ExampleDataReader.GetName(Index));
                }

                Console.WriteLine("Values");
                Console.WriteLine("------");

                while (ExampleDataReader.Read())
                {
                    for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.WriteLine(ExampleDataReader[Index].ToString()); //ToString is to convert to string
                    }
                    Console.WriteLine("-");
                }
            }
            else
            {
                Console.WriteLine("This Student with the @StudentID does not exist.");
            }

            ExampleDataReader.Close();
            MyDataSource.Close();

        }


        static void GetStudentByProgram()
        {
            Console.WriteLine("GetStudentByProgram");
            
            
            //connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();

            
            //Command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetStudentByProgram"  // same name as in the sql
            };



            //Parameter
            SqlParameter MyParameter = new()
            {
                ParameterName = "@ProgramCode",  // same name as in the sql
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Baist"
            };

            MyCommand.Parameters.Add(MyParameter);

            //Reader
            SqlDataReader MyDataReader;
            MyDataReader = MyCommand.ExecuteReader();

            if(MyDataReader.HasRows)
            {
                Console.WriteLine("Columns");
                Console.WriteLine("-------");


                for (int Index = 0; Index < MyDataReader.FieldCount; Index++)
                {
                    Console.WriteLine(MyDataReader.GetName(Index));
                }

                Console.WriteLine("Values");
                Console.WriteLine("------");

                while (MyDataReader.Read())
                {
                    for (int Index = 0; Index < MyDataReader.FieldCount; Index++)
                    {
                        Console.WriteLine(MyDataReader[Index].ToString()); //ToString is to convert to string
                    }
                    Console.WriteLine("-");
                }
            }
            else
            {
                Console.WriteLine("This Student with the @StudentID does not exist.");
            }

            MyDataReader.Close();
            MyDataSource.Close();

        }

        static void GetCustomersByCountry()
        {
            Console.WriteLine("Sample result for United Kingdom");
            Console.WriteLine("---------------------------------");
            SqlConnection MyDataSource = new();

            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();

            SqlCommand ExampleCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "emallo1.GetCustomersByCountry"  // same name as in the sql
            };


            SqlParameter ExampleCommandParameter = new()
            {
                ParameterName = "@country",  // same name as in the sql
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "UK"
            };

            ExampleCommand.Parameters.Add(ExampleCommandParameter);

            SqlDataReader ExampleDataReader;
            ExampleDataReader = ExampleCommand.ExecuteReader();

            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Country Columns:");


                for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                {
                    Console.Write(ExampleDataReader.GetName(Index));
                    Console.Write(";");
                }
                Console.WriteLine("");
                Console.WriteLine("-");
                Console.WriteLine("Country Values:");

                while (ExampleDataReader.Read())
                {
                    for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.Write(ExampleDataReader[Index].ToString()); //ToString is to convert to string
                        Console.Write(";");
                    }
                    Console.WriteLine("");

                }
                Console.WriteLine("-");
            }
            //else
            //{
            //    Console.WriteLine("This Student with the @StudentID does not exist.");
            //}

            ExampleDataReader.Close();
            MyDataSource.Close();

        }
        static void GetCategory()
        {
            Console.WriteLine("Sample result for Diary Products");
            Console.WriteLine("---------------------------------");
            SqlConnection MyDataSource = new();

            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();

            SqlCommand ExampleCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "emallo1.GetCategory"  // same name as in the sql
            };


            SqlParameter ExampleCommandParameter = new()
            {
                ParameterName = "@CategoryID",  // same name as in the sql
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "4"
            };

            ExampleCommand.Parameters.Add(ExampleCommandParameter);

            SqlDataReader ExampleDataReader;
            ExampleDataReader = ExampleCommand.ExecuteReader();

            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Category Columns:");


                for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                {
                    Console.Write(ExampleDataReader.GetName(Index));
                    Console.Write(";");
                }
                Console.WriteLine("");
                Console.WriteLine("-");
                Console.WriteLine("Category Values:");

                while (ExampleDataReader.Read())
                {
                    for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.Write(ExampleDataReader[Index].ToString()); //ToString is to convert to string
                        Console.Write(";");
                    }
                    Console.WriteLine("");

                }
                Console.WriteLine("-");
            }
            //else
            //{
            //    Console.WriteLine("This Student with the @StudentID does not exist.");
            //}

            ExampleDataReader.Close();
            MyDataSource.Close();

        }
        static void GetProductsByCategory()
        {
            SqlConnection MyDataSource = new();

            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";

            MyDataSource.Open();

            SqlCommand ExampleCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "emallo1.GetProductsByCategory"  // same name as in the sql
            };


            SqlParameter ExampleCommandParameter = new()
            {
                ParameterName = "@CategoryID",  // same name as in the sql
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "4"
            };

            ExampleCommand.Parameters.Add(ExampleCommandParameter);

            SqlDataReader ExampleDataReader;
            ExampleDataReader = ExampleCommand.ExecuteReader();

            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Product Columns:");


                for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                {
                    Console.Write(ExampleDataReader.GetName(Index));
                    Console.Write(";");
                }
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("-");
                Console.WriteLine("Product Values:");
                while (ExampleDataReader.Read())
                {
                    for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.Write(ExampleDataReader[Index].ToString()); //ToString is to convert to string
                        Console.Write(";");
                    }
                    Console.WriteLine("");

                }
            }
            //else
            //{
            //    Console.WriteLine("This Student with the @StudentID does not exist.");
            //}

            ExampleDataReader.Close();
            MyDataSource.Close();

        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //AddProgram();
            //AddStudent();
            //UpdateStudent();
            //GetPrograms();
            //GetProgram();   //scaler
            //DeleteStudent();
            //GetStudent();



            ////Test Domain.Student
            ////-------------------
            //BAIS3150ConsoleApp2.Domain.Student AcceptedStudent = new();
            //AcceptedStudent.StudentID = "Test";
            //AcceptedStudent.FirstName = "TestFirstName";
            //AcceptedStudent.LastName = "TestLastName";
            //AcceptedStudent.Email = "Test@nait.ca";

            //Console.WriteLine(AcceptedStudent.StudentID);
            //Console.WriteLine(AcceptedStudent.FirstName);
            //Console.WriteLine(AcceptedStudent.LastName);
            //Console.WriteLine(AcceptedStudent.Email);








            ////1
            //// ###########################################################################################################
            //// Creates Program: ProgramManager John Doe creates the BAIST program using AddProgram
            //// ###########################################################################################################
            //// Test TechnicalServices.Programs (CLASS)
            ////-------------------------------
            //// AddProgram (METHOD in Program CLASS)
            //// prototype   AddProgram(ProgramCode:String, Description:String):Boolean
            //// explained   AddProgram return Boolean and takes 2 argument, ProgramCode whcih is a strint value and Description also a string


            //bool Success;
            //Programs ProgramManager = new();
            //Success = ProgramManager.AddProgram("Test4", "Desc4");
            //Console.WriteLine(Success);



            ////1
            //// ###########################################################################################################
            //// Creates Program: RequestDirector John Doe creates the BAIST program using CreateProgram
            //// ###########################################################################################################
            //// Test Domain.BCS   (CLASS)
            //// ---------------
            //// CreateProgram (METHOD in BSC CLASS) 
            //// prototype    CreateProgram(ProgramCode:String, Description:String):Boolean
            //// explained   CreateProgram return Boolean and takes 2 argument, ProgramCode whcih is a strint value and Description also a string

            //bool Confirmation;
            //BCS RequestDirector = new();
            //Confirmation = RequestDirector.CreateProgram("Test6", "Desc6");
            //Console.WriteLine(Confirmation);





            ////2
            ////###########################################################################################################
            //// Add Student: AcceptedStudent  John Doe finds Mary Smith using AddStudent
            ////Add Student: Test TechnicalServices.Students
            ////-------------------------------
            ////AddStudent
            //bool Success;
            //Student AcceptedStudent = new()
            //{
            //    StudentID = "TEST2",
            //    FirstName = "TestFirstName2",
            //    LastName = "TestLastName2",
            //    Email = "Test2@nait.ca",
            //};

            //Students StudentManager = new();
            //Success = StudentManager.AddStudent(AcceptedStudent, "TEST");
            //Console.WriteLine(Success);


            ////2
            ////###########################################################################################################
            //// Enroll Student: AcceptedStudent  John Doe finds Mary Smith using EnrollStudent
            ////Add Student:
            ////-------------------------------
            //// Test Domain.BCS
            //// ---------------
            //// EnrollStudent
            //bool Confirmation;

            //Student AcceptedStudent = new()
            //{
            //    StudentID = "Test6",
            //    FirstName = "TestFirstName6",
            //    LastName = "TestLastName6",
            //    Email = "Test6@nait.ca"
            //};

            //BCS RequestDirector = new();

            //Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, "Test6");
            //Console.WriteLine(Confirmation);










            ////3
            ////###########################################################################################################
            //// Get Student: StudentManager John Doe finds Mary Smith using GetStudent
            ////###########################################################################################################
            ////Test TechnicalServices.Students (CLASS)
            ////-------------------------------
            ////GetStudent (METHOD in Student CLASS)            
            ////prototype    GetStudent(StudentID:String):Student
            ////explained    GetStudent return Student instance/datatype, and takes 1 argument StudentID


            //Students StudentManager = new();
            //Student EnrolledStudent = StudentManager.GetStudent("2001");  //student = student getter/Setter construct
            //Console.WriteLine(EnrolledStudent.StudentID);
            //Console.WriteLine(EnrolledStudent.FirstName);
            //Console.WriteLine(EnrolledStudent.LastName);
            //Console.WriteLine(EnrolledStudent.Email);



            ////3
            //// ###########################################################################################################
            //// Find Student: RequestDirector John Doe find Mary Smith using FindStudent
            //// ###########################################################################################################
            //// Test Domain.BCS   (class)
            //// ---------------
            //// FindStudent (method in bsc class) 
            //// prototype    FindStudent(studentid:string):Student
            //// explained    FindStudent return Student instance/datatype, and takes 1 argument studentid

            //BCS Requestdirector = new();
            //Student EnrolledStudent = Requestdirector.FindStudent("Test6");
            //Console.WriteLine(EnrolledStudent.StudentID);
            //Console.WriteLine(EnrolledStudent.FirstName);
            //Console.WriteLine(EnrolledStudent.LastName);
            //Console.WriteLine(EnrolledStudent.Email);







            ////4
            //// ###########################################################################################################
            //// Modify Student: StudentManager John Doe modifies Mary Smith using GetStudent and Update Student
            // ###########################################################################################################
            // Test Domain.Students (CLASS)
            // -------------------------------
            // Modify (METHOD in Student CLASS)            
            // prototype    GetStudent(StudentID:String):Student
            // explained    GetStudent return Student instance/datatype, and takes 1 argument StudentID
            // steps >> use BCS.FindStudent to return Enrolled student then
            // supplly the new values that will replace the old value in enrolledStudent and then
            // call Students.ModifyStudent to replace with the new value


            //Students StudentManager = new();
            //Student EnrolledStudent = StudentManager.GetStudent("2004");
            //Console.WriteLine(EnrolledStudent.StudentID);
            //Console.WriteLine(EnrolledStudent.FirstName);
            //Console.WriteLine(EnrolledStudent.LastName);
            //Console.WriteLine(EnrolledStudent.Email);

            ////new_values
            //EnrolledStudent.StudentID = "2004";
            //EnrolledStudent.FirstName = "Test2";
            //EnrolledStudent.LastName = "Test2";
            //EnrolledStudent.Email = "Test2@nait.ca";


            //bool Success = false;
            //Success = StudentManager.UpdateStudent(EnrolledStudent);

            //Console.WriteLine("Update status = " + Success);
            //Console.WriteLine("---------------------------------------------\n ");

            //Student EnrolledStudent2 = StudentManager.GetStudent("Test2");










            ////4
            //// ###########################################################################################################
            //// Modify Student: RequestDirector John Doe modified Mary Smith using FindStudent and ModifyStudent
            //// ###########################################################################################################
            //// Test Domain.BCS (CLASS)
            //// -------------------------------
            //// Modify (METHOD in Student CLASS)            
            //// prototype    GetStudent(StudentID:String):Student
            //// explained    GetStudent return Student instance/datatype, and takes 1 argument StudentID
            //// steps >> use BCS.FindStudent to return Enrolled student then
            //// supplly the new values that will replace the old value in enrolledStudent and then
            //// call Students.ModifyStudent to replace with the new value


            //BCS Requestdirector = new();
            //Student EnrolledStudent = Requestdirector.FindStudent("Test6");
            //Console.WriteLine(EnrolledStudent.StudentID);
            //Console.WriteLine(EnrolledStudent.FirstName);
            //Console.WriteLine(EnrolledStudent.LastName);
            //Console.WriteLine(EnrolledStudent.Email);

            ////new_values
            //EnrolledStudent.StudentID = "Test6";
            //EnrolledStudent.FirstName = "Arvind";
            //EnrolledStudent.LastName = "Pandit";
            //EnrolledStudent.Email = "arvind1@nait.ca";

            //bool Confirmation = false;            
            //Confirmation = Requestdirector.ModifyStudent(EnrolledStudent);

            //Console.WriteLine("Update status = " + Confirmation);
            //Console.WriteLine("---------------------------------------------\n ");


















            ///5
            //// ###########################################################################################################
            //// Remove Student: StudentManager John Doe removes Mary Smith using GetStudent and DeleteStudent
            ////###########################################################################################################
            ////Test TechnicalServices.Students (CLASS)
            ////-------------------------------
            ////Delete(METHOD in Student CLASS)            
            ////prototype    DeleteStudent(StudentID:String):Boolean
            ////explained    DeleteStudent return Boolean datatype, and takes 1 argument StudentID




            //Students StudentManager = new();
            //Student EnrolledStudent = StudentManager.GetStudent("Example1");
            //Console.WriteLine(EnrolledStudent.StudentID);
            //Console.WriteLine(EnrolledStudent.FirstName);
            //Console.WriteLine(EnrolledStudent.LastName);
            //Console.WriteLine(EnrolledStudent.Email);

            //bool Success = false;

            //Success = StudentManager.DeleteStudent(EnrolledStudent.StudentID);
            //Console.WriteLine("Delete status = " + Success);






            ////5
            //// ###########################################################################################################
            //// Remove Student: RequestDirector John Doe removes Mary Smith using FindStudent and RemoveStudent
            ////###########################################################################################################
            //// Test Domain.BCS   (class)
            //// ---------------
            //// RemoveStudent(StudentID:String):Boolean
            //// prototype   RemoveStudent(StudentID:String):Boolean
            ////explained    RemoveStudent return Boolen, and takes 1 argument StudentID

            //bool Confirmation = false;

            //BCS Requestdirector = new();
            //Student EnrolledStudent = Requestdirector.FindStudent("Test6");
            //Console.WriteLine(EnrolledStudent.StudentID);
            //Console.WriteLine(EnrolledStudent.FirstName);
            //Console.WriteLine(EnrolledStudent.LastName);
            //Console.WriteLine(EnrolledStudent.Email);

            //Confirmation = Requestdirector.RemoveStudent(EnrolledStudent.StudentID);
            //Console.WriteLine("Delete status = " + Confirmation);














            ////6
            //// ###########################################################################################################
            //// Find Program: StudentManagerr John Doe finds the BAIST program using GetStudents 
            ////###########################################################################################################
            ////Test TechnicalServices.Students(CLASS)
            ////-------------------------------
            ////FindProgram(METHOD in Programs CLASS)            
            ////prototype    GetStudents(ProgramCode:string:Student[*]


            //Students StudentManager = new();
            //List<Student> EnrolledStudents = StudentManager.GetStudents("BAIST");
            //foreach (Student enrolledStudent in EnrolledStudents)
            //{
            //    Console.WriteLine(enrolledStudent.StudentID);
            //    Console.WriteLine(enrolledStudent.FirstName);
            //    Console.WriteLine(enrolledStudent.LastName);
            //    Console.WriteLine(enrolledStudent.Email);
            //    Console.WriteLine("-------------");

            //}














            //6
            // ###########################################################################################################
            // Find Programs: RequestDirector John Doe finds the BAIST program
            //###########################################################################################################
            //Test TechnicalServices.Programs (CLASS)
            //-------------------------------


            //BCS Requestdirector = new();
            //Domain.Program ActiveProgram = Requestdirector.FindProgram("TEST");
            //Console.WriteLine(ActiveProgram.ProgramCode);
            //Console.WriteLine(ActiveProgram.Description);
            //foreach (Student enrolledStudent in ActiveProgram.EnrolledStudents)
            //{
            //    Console.WriteLine(enrolledStudent.StudentID);
            //    Console.WriteLine(enrolledStudent.FirstName);
            //    Console.WriteLine(enrolledStudent.LastName);
            //    Console.WriteLine(enrolledStudent.Email);
            //    Console.WriteLine("-------------");

            //}








            ////Test User Interface (Console)
            ////------------------------------
            ////EnrollStudent
            ////Get value from user interface
            //string StudentID = string.Empty;
            //string FirstName = string.Empty;
            //string LastName = string.Empty;
            //string Email = string.Empty;
            //string ProgramCode = string.Empty;

            //string? ConsoleLine = string.Empty;
            //Console.WriteLine("Enter StudentID:");
            //if ((ConsoleLine = Console.ReadLine()) != null)
            //{
            //    StudentID = ConsoleLine;
            //}

            //Console.WriteLine("Enter FirstName:");
            //if ((ConsoleLine = Console.ReadLine()) != null)
            //{
            //    FirstName = ConsoleLine;
            //}

            //Console.WriteLine("Enter LastName:");
            //if ((ConsoleLine = Console.ReadLine()) != null)
            //{
            //    LastName = ConsoleLine;
            //}
            //Console.WriteLine("Enter Email:");
            //if ((ConsoleLine = Console.ReadLine()) != null)
            //{
            //    Email = ConsoleLine;
            //}

            //Console.WriteLine("Enter ProgramCode:");
            //if ((ConsoleLine = Console.ReadLine()) != null)
            //{
            //    ProgramCode = ConsoleLine;
            //}


            ////Process
            //bool Confirmation;

            //Student AcceptedStudent = new()
            //{
            //    StudentID = StudentID,
            //    FirstName = FirstName,
            //    LastName = LastName,
            //    Email = Email
            //};

            //BCS RequestDirector = new();
            //Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode);
            //Console.WriteLine(Confirmation);




            //string StudentID = "TEST2";
            //string FirstName = "TestFirstName2";
            //string LastName = "TestLastName2";
            //string Email = "Test@nait.ca";
            //string ProgramCode = "TEST";


            //Student AcceptedStudent = new()
            //{
            //    StudentID = StudentID,
            //    FirstName = FirstName,
            //    LastName = LastName,
            //    Email = Email
            //};

            //bool Confirmation;
            //BCS RequestDirector = new();
            //Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode);
            //Console.WriteLine(Confirmation);




        }
    }
}
