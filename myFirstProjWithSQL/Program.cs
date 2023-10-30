using myFirstProjWithSQL;
using System.Data.SqlClient;
Console.WriteLine("Welcome to my jenious DB!");

//static void Main()
//{
    const string connectionString = "Data Source=DESKTOP-T7J3RR5\\SQLEXPRESS;Initial Catalog=mySingles;Integrated Security=True";
    dbConnection dbConn = new dbConnection();
dbConn.InsertDataP(connectionString);
//dbConn.readDataP(connectionString);
//dbConn.readData(connectionString);
dbConn.readJoinData(connectionString);

//}