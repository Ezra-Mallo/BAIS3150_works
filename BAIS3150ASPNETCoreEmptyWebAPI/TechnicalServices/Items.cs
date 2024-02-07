using BAIS3150ASPNETCoreEmptyWebAPI.Models;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace BAIS3150ASPNETCoreEmptyWebAPI.TechnicalServices
{
    public class Items

    {
        public List<Item> GetItems()
        {
            //connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21;";            
            MyDataSource.Open();

            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText="GetItems"
            };
           
            SqlDataReader MyDataReader = MyCommand.ExecuteReader();


            List<Item> ExampleItems = new();
            if (MyDataReader.HasRows)
            {
                while (MyDataReader.Read()) 
                {
                    Item ExampleItem = new()
                    {
                        ItemNumber = (int)MyDataReader["ItemNumber"],
                        Description = (string)MyDataReader["Description"],
                        UnitPrice = (decimal)MyDataReader["UnitPrice"]
                    };

                    ExampleItems.Add(ExampleItem);

                }
            }
            MyDataReader.Close();
            MyDataSource.Close();

            return ExampleItems;


        }








        public Item GetItem(int itemNumber)
        {
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21;";
            MyDataSource.Open();

            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "GetItem"
            };

            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName ="@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = itemNumber
            };
            MyCommand.Parameters.Add(MyParameter);

            SqlDataReader MyDataReader = MyCommand.ExecuteReader();

            Item ExampleItem = new();

            if (MyDataReader.HasRows)
            {
                MyDataReader.Read();
                ExampleItem.ItemNumber = (int)MyDataReader["ItemNumber"];
                ExampleItem.Description = (string)MyDataReader["Description"];
                ExampleItem.UnitPrice = (decimal)MyDataReader["UnitPrice"];            
            }
            MyDataReader.Close();
            MyDataSource.Close();
            return ExampleItem;

        }









        public void AddItem(Item exampleItem)
        {
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21;";
            MyDataSource.Open();

            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddItem"
            };

            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.Description
            };
            MyCommand.Parameters.Add(MyParameter);


            MyParameter = new()
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Money,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.UnitPrice
            };
            MyCommand.Parameters.Add(MyParameter);

            MyCommand.ExecuteNonQuery();
            MyDataSource.Close();
        }











        public void UpdateItem(int itemNumber, Item exampleItem)
        {
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21;";
            MyDataSource.Open();

            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateItem"
            };
            SqlParameter MyParameter;


            MyParameter = new()
            {
                ParameterName = "@ItemNumber",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.ItemNumber
            };
            MyCommand.Parameters.Add(MyParameter);

            MyParameter = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.Description
            };
            MyCommand.Parameters.Add(MyParameter);


            MyParameter = new()
            {
                ParameterName = "@UnitPrice",
                SqlDbType = SqlDbType.Money,
                Direction = ParameterDirection.Input,
                SqlValue = exampleItem.UnitPrice
            };
            MyCommand.Parameters.Add(MyParameter);




            MyCommand.ExecuteNonQuery();
            MyDataSource.Close();
        }









        public void DeleteItem(int itemNumber)
        {
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;Database=emallo1;server=dev1.baist.ca;User ID=emallo1;Password=Dalu21;";
            MyDataSource.Open();

            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteItem"
            };            
            

            SqlParameter MyParameter;
            MyParameter = new()
            {
                ParameterName = "@ItemNumber",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = itemNumber
            };
            MyCommand.Parameters.Add(MyParameter);

            MyCommand.ExecuteNonQuery();
            MyDataSource.Close();


        }

    }
}
