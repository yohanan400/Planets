using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public List<PlanetsBE.Neo> GetBetweenDatesNeos(DateTime start, DateTime end)
        {
            string url = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start.GetDateTimeFormats()[7]}&end_date={end.GetDateTimeFormats()[7]}&api_key={API_KEY}";

            using (WebClient client = new WebClient())
            {
                //Download Json file
                Uri downloadURI = new Uri(url);
                var stream = client.DownloadString(downloadURI);
                dynamic jsonFile = JsonConvert.DeserializeObject(stream);


                List<PlanetsBE.Neo> neos = new List<PlanetsBE.Neo>();

                JObject obj = JObject.Parse(stream);
                var jarr = obj["near_earth_objects"].Value<JToken>();

                foreach (var itm in jarr)
                {
                    foreach (var item in itm)
                    {
                        neos.AddRange(from it in item
                                select new PlanetsBE.Neo
                                {
                                    SerchDate = DateTime.Parse(((JProperty)itm).Name),


                                    Id = (int)it["id"],
                                    Name = (string)it["name"],
                                    EstimatedDiameter = (float)it["estimated_diameter"]["kilometers"]["estimated_diameter_min"],
                                    IsPotentiallyHazardousAsteroid = (bool)it["is_potentially_hazardous_asteroid"]

                                });
                    }
                }
                return neos;
            }
        }
    }
}
