using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database

{
    public class Msql
    {
        public void M1sql()

        {

        using (SqlConnection conn = new SqlConnection())
        {
            string s3 = "Server =localhost; Database =GrosseryList; Integrated Security=SSPI;Persist Security Info=False;";

            conn.ConnectionString = s3;
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT [Id] ,[Name], [Price], [GrosCategory] FROM[dbo].[Grossery]", conn);


            var items = new List<Product>();

            using (SqlDataReader reader1 = command.ExecuteReader())
            {

                Console.WriteLine("FirstColumn\tSecond Column\t Third Column\t Forth Column\t");
                while (reader1.Read())
                {

                    Product item = new Product(int.Parse(reader1[0].ToString()), (reader1[1].ToString()),
                        decimal.Parse(reader1[2].ToString()), (reader1[3].ToString()));
                    items.Add(item);

                   



                }
            }
            string jsonData = JsonConvert.SerializeObject(items);// ** save to json
            System.IO.File.WriteAllText("Jsondata.txt", jsonData);



            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

        }
    }

    
        public void InsertDB()
        {
            var items = new List<Product>();

            string data = File.ReadAllText("Jsondata.txt");
            var tempItem = JsonConvert.
                DeserializeObject<List<Product>>(data); // Load from json file
            foreach (Product t in tempItem)
            {
                items.Add(t);

            }
            using (SqlConnection conn = new SqlConnection())
            {
                string s3 = "Server =localhost; Database =GrosseryList; Integrated Security=SSPI;Persist Security Info=False;";

                conn.ConnectionString = s3;
                conn.Open();

                foreach (var t in items)
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Grossery (Name, Price, GrosCategory)" +
                        "" +
                        " VALUES (@0,@1,@2)", conn);


                    insertCommand.Parameters.Add(new SqlParameter("0", (t.Name)));
                    insertCommand.Parameters.Add(new SqlParameter("1", (t.Price)));
                    insertCommand.Parameters.Add(new SqlParameter("2", int.Parse(t.Category)));
                    int c = insertCommand.ExecuteNonQuery();
                }



            }



        }


    }



}
