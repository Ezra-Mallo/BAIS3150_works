using BAIS3150ServicesAssignmentWebAPI.Model;
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace BAIS3150ServicesAssignmentWebAPI.TechnicalServices
{
    public class Customers
    {
        public List<Customer> GetCustomers()
        {
            
            //sqlconnection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //Command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "emallo1.GetNorthwindCustomers"
            };

            //DataReader
            SqlDataReader MyDataReader = MyCommand.ExecuteReader();


            List<Customer> customers = new();
            if (MyDataReader.HasRows)
            {                
                while (MyDataReader.Read())
                {
                    Customer customer = new()
                    {
                        CustomerID = MyDataReader["CustomerID"] is DBNull ? null : (string)MyDataReader["CustomerID"],
                        CompanyName = MyDataReader["CompanyName"] is DBNull ? null : (string)MyDataReader["CompanyName"],
                        ContactName = MyDataReader["ContactName"] is DBNull ? null : (string)MyDataReader["ContactName"],
                        ContactTitle = MyDataReader["ContactTitle"] is DBNull ? null : (string)MyDataReader["ContactTitle"],
                        Address = MyDataReader["Address"] is DBNull ? null : (string)MyDataReader["Address"],
                        City = MyDataReader["City"] is DBNull ? null : (string)MyDataReader["City"],
                        Region = MyDataReader["Region"] is DBNull ? null : (string)MyDataReader["Region"],
                        PostalCode = MyDataReader["PostalCode"] is DBNull ? null : (string)MyDataReader["PostalCode"],
                        Country = MyDataReader["Country"] is DBNull ? null : (string)MyDataReader["Country"],
                        Phone = MyDataReader["Phone"] is DBNull ? null : (string)MyDataReader["Phone"],
                        Fax = MyDataReader["Fax"] is DBNull ? null : (string)MyDataReader["Fax"]
                };
                    customers.Add(customer);
                }
                
            }
            MyDataReader.Close();
            MyDataSource.Close();

            return customers;
        }











        public Customer GetCustomer(string CustomerID)
        {

            //sqlconnection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=Northwind;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //Command
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "emallo1.GetNorthwindCustomer"
            };

            //SqlParameter
            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@CustomerID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = CustomerID
            };
            MyCommand.Parameters.Add(MyParameter);


            //DataReader
            SqlDataReader MyDataReader;
            MyDataReader = MyCommand.ExecuteReader();
            Customer customer = new();

            if (MyDataReader.HasRows)
            {
                // Move to the first row
                MyDataReader.Read();

                int countryOrdinal;

                // Check if the 'Country' column exists before accessing it
                try
                {
                    countryOrdinal = MyDataReader.GetOrdinal("Country");
                }
                catch (IndexOutOfRangeException)
                {
                    countryOrdinal = -1; // Set to -1 if the column doesn't exist
                }

                customer.CustomerID = MyDataReader["CustomerID"] is DBNull ? null : (string)MyDataReader["CustomerID"];
                customer.CompanyName = MyDataReader["CompanyName"] is DBNull ? null : (string)MyDataReader["CompanyName"];
                customer.ContactName = MyDataReader["ContactName"] is DBNull ? null : (string)MyDataReader["ContactName"];
                customer.ContactTitle = MyDataReader["ContactTitle"] is DBNull ? null : (string)MyDataReader["ContactTitle"];
                customer.Address = MyDataReader["Address"] is DBNull ? null : (string)MyDataReader["Address"];
                customer.City = MyDataReader["City"] is DBNull ? null : (string)MyDataReader["City"];
                customer.Region = MyDataReader["Region"] is DBNull ? null : (string)MyDataReader["Region"];
                customer.PostalCode = MyDataReader["PostalCode"] is DBNull ? null : (string)MyDataReader["PostalCode"];

                // Check if the 'Country' column exists before accessing it
                if (countryOrdinal != -1)
                {
                    customer.Country = MyDataReader["Country"] is DBNull ? null : (string)MyDataReader["Country"];
                }

                customer.Phone = MyDataReader["Phone"] is DBNull ? null : (string)MyDataReader["Phone"];
                customer.Fax = MyDataReader["Fax"] is DBNull ? null : (string)MyDataReader["Fax"];
            }

            MyDataReader.Close();
            MyDataSource.Close();
            return customer;

        }
    }
}
