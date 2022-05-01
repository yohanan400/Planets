using System.Data.SqlClient;

namespace PlanetsDAL
{
    partial class PlanetsDal
    {
        SqlConnection conn = new SqlConnection();
        const string API_KEY = "Ge2ay3CtDiciZEJ3z1BAb0rQS9GElv8LIrntvwCJ";
        public void ConnectToDB()
        {
            //prepare conectio string
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\yakir\test.mdf;Integrated Security=True;Connect Timeout=30";

            conn.Open();
        }

        public void DisconnectFromDB()
        {
            conn.Close();
        }

    }
}