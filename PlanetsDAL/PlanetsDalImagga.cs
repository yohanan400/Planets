using MySql.Data.MySqlClient.Memcached;
using Newtonsoft.Json.Linq;
using PlanetsBE;
using RestSharp;
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
        public async void GetImmaga(string imageUrl)
        {
            string apiKey = "acc_4f8b1e5711e45e8";
            string apiSecret = "cdfcd97ec074a601b8dc133f89d85b8b";
            //string url = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start.GetDateTimeFormats()[7]}&end_date={end.GetDateTimeFormats()[7]}&api_key={API_KEY}";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            using (RestClient client = new RestClient())
            {
                //Download Json file
                
                var request = new RestRequest("https://api.imagga.com/v2/tags", Method.Get);
                request.AddParameter("image_url", imageUrl);
                request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

                RestResponse response = await client.ExecuteAsync(request);

                List<ImaggaObj> imaggaObjs = new List<ImaggaObj>();

                JObject obj = JObject.Parse(response.Content);

                var jarr = obj["result"]["tags"].Value<JToken>();

                foreach (var item in jarr)
                {
                    imaggaObjs.Add(new ImaggaObj
                    {
                        Tag = (string)item["tag"]["en"],
                        Confidence = (int)item["confidence"]
                    });

                }
            }
        }
    }
}
