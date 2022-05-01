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


                foreach (var item in jarr)
                {
                    PlanetsBE.Neo neo = new PlanetsBE.Neo();

                    //neo.SerchDate = (DateTime)item;

                    //var v = from item

                    neos.Add(neo);
                }
                return neos;
            }
        }
    }
}
