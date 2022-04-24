using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PlanetsBE;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public Planet GetPlanetByName(string name)
        {
            ConnectToDB();

            string query = $"select * from Planet where name='{name}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader SqlDataReader = cmd.ExecuteReader();
            SqlDataReader.Read();

            object[] arr = new object[14];
            SqlDataReader.GetValues(arr);

            Planet planet = new Planet();


            
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

        public List<Planet> GetAllPlanets()
        {
            ConnectToDB();

            string query = $"select * from Planet";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            SqlDataReader SqlDataReader = cmd.ExecuteReader();

            object[] arr = new object[14];
            
            List<Planet> planets = new List<Planet>();
            
            

            while (SqlDataReader.Read())
            {
                SqlDataReader.GetValues(arr);

                Planet planet = new Planet();
                int i = 0;
                foreach (var item in planet.GetType().GetProperties())
                {

                    item.SetValue(planet, Convert.ChangeType(Convert.ChangeType(arr[i], arr[i].GetType()), item.PropertyType));
                    ++i;
                }

                planets.Add(planet);
            }

            DisconnectFromDB();

            return planets;


        }
    }
}
