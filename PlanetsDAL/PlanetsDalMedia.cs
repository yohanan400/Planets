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

        public List<PlanetsBE.MediaInfo> GetMediaFromNasa(string subject)
        {
            string url = "https://images-api.nasa.gov/search?q=";
            if (subject == string.Empty)
            {
                url += "Earth";
            }
            else
            {
                url += subject;
            }

            using (WebClient client = new WebClient())
            {
                //Download Json file
                Uri downloadURI = new Uri(url);
                var stream = client.DownloadString(downloadURI);

                List<PlanetsBE.MediaInfo> mediaInfos = new List<PlanetsBE.MediaInfo>();

                JObject obj = JObject.Parse(stream);
                var jarr = obj["collection"]["items"].Value<JArray>();


                foreach (var item in jarr)
                {
                    PlanetsBE.MediaInfo mediaInfo = new PlanetsBE.MediaInfo();

                    mediaInfo.Title = (string)item["data"][0]["title"];
                    mediaInfo.Description = (string)item["data"][0]["description"];
                    mediaInfo.DateCreated = (DateTime)item["data"][0]["date_created"];
                    mediaInfo.MediaType = (string)item["data"][0]["media_type"];
                    if (mediaInfo.MediaType != "audio")
                    {
                        mediaInfo.Href = (string)item["links"][0]["href"];
                    }else
                    {
                        mediaInfo.Href = @"https://firebasestorage.googleapis.com/v0/b/planets-d4e9c.appspot.com/o/Icons%2Faudio-sound-speaker-volume-icon-516766.png?alt=media&token=e2bc35b0-4e23-4ba0-95e8-a14632251e2c";
                    }

                    mediaInfos.Add(mediaInfo);
                }
                return mediaInfos;
            }
        }
    }
}
