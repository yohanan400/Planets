using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PlanetsBE;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public void AddPlanet(Planet planet)
        {
            string query = "insert planet values(" +
                planet.Id + ", '" +
                planet.Name + "', '" +
                planet.Type + "', " +
                planet.Mass + ", " +
                planet.TrackRadius + ", " +
                planet.DurationOfRoute + ", " +
                planet.TrackInclination + ", " +
                planet.Diameter + ", " +
                planet.Eccentricity + ", " +
                planet.DayLength + ", " +
                planet.Moons + ", " +
                planet.PlanetaryRings + ", " +
                planet.Atmospheres + ", " +
                planet.ProfilePicture + ")";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            ConnectToDB();
            cmd.ExecuteNonQuery();
            DisconnectFromDB();
        }

        public Planet GetPlanetByName(string name)
        {
            string query = $"select * from Planet where name='{name}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            ConnectToDB();
            SqlDataReader SqlDataReader = cmd.ExecuteReader();
            SqlDataReader.Read();
            
            object[] arr = new object[14];
            SqlDataReader.GetValues(arr);
            DisconnectFromDB();

            Planet planet = new Planet();

            object[] planetsProps = planet.GetType().GetProperties();

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

        public void UpdatePlanetByName(string name,    Planet planet)
        {
            Planet currentPlanet = GetPlanetByName(name);

            string query = "update planet set " +
            "name ='" + planet.Name + "', " +
            "type ='" + planet.Type + "', " +
            "mass =" + planet.Mass + ", " +
            "trackRadius =" + planet.TrackRadius + ", " +
            "DurationOfRoute =" + planet.DurationOfRoute + ", " +
            "TrackInclination =" + planet.TrackInclination + ", " +
            "Diameter =" + planet.Diameter + ", " +
            "Eccentricity =" + planet.Eccentricity + ", " +
            "DayLength =" + planet.DayLength + ", " +
            "Moons =" + planet.Moons + ", " +
            "PlanetaryRings =" + planet.PlanetaryRings + ", " +
            "Atmosphere =" + planet.Atmospheres + ", " +
            "ProfilePicture =" + planet.ProfilePicture +
            "where id = " + planet.Id;

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.Text;

            ConnectToDB();
            cmd.ExecuteNonQuery();
            DisconnectFromDB();

        }

        public void DeletePlanetByName(string name)
        {
            string query = $"delete from planet where name ='{name}'";
            SqlCommand cmd = new SqlCommand(query, conn);

            ConnectToDB();
            cmd.ExecuteNonQuery();
            DisconnectFromDB();
        }
    }
}
