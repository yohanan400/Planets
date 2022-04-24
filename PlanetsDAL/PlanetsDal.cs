using System.Data.SqlClient;

namespace PlanetsDAL
{
    partial class PlanetsDal
    {
            SqlConnection conn = new SqlConnection();

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