using BAIS3150_UI_Razor_Pages_Assignment.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Data;

namespace BAIS3150_UI_Razor_Pages_Assignment.TechnicalServices
{
    public class Categories
    {
        public List<Category> FindCategories()
        {
            List<Category> FoundCategories = new();

            //connection
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False;DataBase=Northwind;Server=dev1.baist.ca;User ID=emallo1;Password=Dalu21";
            MyDataSource.Open();

            //DataCommand
            SqlCommand MyCommand = new()
            {
                Connection = MyDataSource,
                CommandType = CommandType.StoredProcedure,
                CommandText = "emallo1.GetNorthwindCategories"
            };


            //Reader
            SqlDataReader MyDataReader = MyCommand.ExecuteReader();
            if (MyDataReader.HasRows)
            {
                
                while (MyDataReader.Read())
                {
                    Category aCategory = new()
                    {
                        CategoryName = (string)MyDataReader["CategoryName"],
                        Description = (string)MyDataReader["Description"],
                        Picture = (byte[])MyDataReader["Picture"]
                    };
                    FoundCategories.Add(aCategory);
                }
            }
            return FoundCategories;
        }
        
        
    }
}
