using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsDAL
{
    partial class PlanetsDal
    {
        OracleConnection conn = new OracleConnection();

        public void ConnectToDB()
        {
            conn.ConnectionString = "User Id=SYSTEM; Password=admin; Data Source=xe;";
            conn.Open();
        }

        public void DisconnectFromDB()
        {
            conn.Close();
        }
    }
}
