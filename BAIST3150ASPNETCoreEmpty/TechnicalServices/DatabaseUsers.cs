using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using BAIST3150ASPNETCoreEmpty.Domain;


    
    namespace BAIST3150ASPNETCoreEmpty.TechnicalServices
{
    public class DatabaseUsers
    {

        private string? _connectionString;   // the ? helps to remove the nullable reference on the _connectionString
        // private string _connectionString;  

        public DatabaseUsers()
        {
            //constructor logic
            ConfigurationBuilder DatabaseUserBuilder = new();
            DatabaseUserBuilder.SetBasePath(Directory.GetCurrentDirectory());
            DatabaseUserBuilder.AddJsonFile("appsettings.json");
            IConfiguration DatabaseUserConfiguration = DatabaseUserBuilder.Build();
            _connectionString = DatabaseUserConfiguration.GetConnectionString("varBAIS3150");  //to remove the error'
            //_connectionString = DatabaseUserConfiguration.GetConnectionString("VarBAIS3150")!;  //null forgiving operator  - !


        }

        public DatabaseUser GetDatabaseUsers()
        {        
            //SqlConnection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = _connectionString;
            MyDataSource.Open();

            //commands
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetDatabaseUser"
            };

            SqlDataReader MyDataReader = MyCommand.ExecuteReader();

            DatabaseUser CurrentDatabaseUser = new();   // DatabaseUser is referenced  from domain

            if(MyDataReader.HasRows)
            {
                MyDataReader.Read();

                CurrentDatabaseUser.CurrentUser = (string)MyDataReader["CurrentUser"];
                CurrentDatabaseUser.SystemUser = (string)MyDataReader["SystemUser"];
                CurrentDatabaseUser.SessionUser = (string)MyDataReader["SessionUser"];
            }
            MyDataReader.Close();
            MyDataSource.Close();
            return CurrentDatabaseUser;
        }

    }
}
