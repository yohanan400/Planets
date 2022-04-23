using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using PlanetsBE;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public Planet GetPlanetByName(string name)
        {
            ConnectToDB();

            string query = $"select * from Planet where name='{name}'";
            OracleCommand cmd = new OracleCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            OracleDataReader oracleDataReader = cmd.ExecuteReader();
            oracleDataReader.Read();

            object[] arr = new object[14];
            oracleDataReader.GetValues(arr);

            Planet planet = new Planet();


            planet.Id = (int)(decimal)arr[0];
            object[] planetsProps = planet.GetType().GetProperties();
            DisconnectFromDB();

            
            int i = 0;
            foreach (var item in planet.GetType().GetProperties())
            {

                item.SetValue(planet, Convert.ChangeType(Convert.ChangeType(arr[i], arr[i].GetType()), item.PropertyType));
                ++i;
            }
            
            return planet;

            
        }
    }
}
