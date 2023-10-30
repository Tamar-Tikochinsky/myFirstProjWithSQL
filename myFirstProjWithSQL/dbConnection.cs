using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myFirstProjWithSQL
{
    public class dbConnection
    {
        //פונקציה המשמשת לפתיחת אפשרות שיחה עם מסד הנתונים
        private static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }

        }
        //הכנסת קטגוריות
        public int InsertDataC(string connectionString) { 
            string categoryId, categoryName;
            Console.WriteLine("Insert categoryName:");
            categoryName = Console.ReadLine();

            string query = "INSERT INTO Category(categoryName)" +
                           "VALUES (@categoryName)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            { 
                cmd.Parameters.Add("@categoryName",SqlDbType.VarChar,50).Value = categoryName;

                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " " + "rowsAffected");
                cn.Close();

                return rowsAffected;
            }
        }

        public int InsertDataP(string connectionString)
        {
            string PersonName, CategoryId, PersonDesc, PersonImage;
            Console.WriteLine("Insert PersonName:");
            PersonName = Console.ReadLine();
            Console.WriteLine("Insert CategoryId:");
            CategoryId = Console.ReadLine();
            Console.WriteLine("Insert PersonDesc:");
            PersonDesc = Console.ReadLine();
            Console.WriteLine("Insert PersonImage:");
            PersonImage = Console.ReadLine();

            string query = "INSERT INTO People(PersonName,CategoryId,PersonDesc,PersonImage)" +
                           "VALUES (@PersonName,@CategoryId,@PersonDesc,@PersonImage)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@PersonName", SqlDbType.VarChar, 50).Value = PersonName;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                cmd.Parameters.Add("@PersonDesc", SqlDbType.VarChar, 50).Value = PersonDesc;
                cmd.Parameters.Add("@PersonImage", SqlDbType.VarChar, 50).Value = PersonImage;

                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine(rowsAffected + " " + "rowsAffected");
                cn.Close();

                return rowsAffected;
            }
        }


        public void readData(string connectionString) {

            string queryString = "select * from Category ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                Console.ReadLine();
            }
        }

        public void readDataP(string connectionString)
        {

            string queryString = "select * from People";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            reader[0], reader[1], reader[2], reader[3] , reader[4]);
                    }
                    reader.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                Console.ReadLine();
            }
        }

        public void readJoinData(string connectionString)
        {

            string queryString = "SELECT c.CategoryName, p.*" +
                     "FROM Category c JOIN People p ON c.CategoryId = p.CategoryId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                            reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                    }
                    reader.Close();
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                Console.ReadLine();
            }
        }
    }
}
