using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public void AddPicture(PlanetsBE.Picture picture)
        {
            string firebasePath = UploadPictureToFireBase(picture);
            
            using (PlanetsEntities context = new PlanetsEntities())
            {
                context.Pictures.Add(new Picture { PlanetId = picture.PlanetId, Path = firebasePath, PictureName = picture.PictureName });
                context.SaveChanges();
            }
        }

        public Byte[] GetPictureById(int pictureId)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                var v = context.Pictures.FirstOrDefault(x => x.Id == pictureId);
                
                using (WebClient client = new WebClient())
                {
                    Uri downloadURI = new Uri(v.Path);

                    return client.DownloadData(downloadURI);
                }
            }
        }

        public IEnumerable<int> GetPicturesIds()
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                List<Picture> pictures = new List<Picture>(context.Pictures);
                return from picture in pictures select picture.Id;
            }
        }

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
                dynamic jsonFile = JsonConvert.DeserializeObject(stream);


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
                    }

                    mediaInfos.Add(mediaInfo) ;
                } 
                return mediaInfos;
            }
        }
        public void UpdatePicture(PlanetsBE.Picture picture)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                Picture result = context.Pictures.FirstOrDefault(x => x.Id == picture.Id);
                result = ClonePicture(picture);

                context.SaveChanges();
            }
        }

        public void DeletePictureById(int pictureId)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                Picture picture = context.Pictures.FirstOrDefault(x => x.Id == pictureId);
                DeletePictureFromFirebase(picture);
                context.Pictures.Remove(picture);
                
                context.SaveChanges();
            }
        }

        public Picture ClonePicture(PlanetsBE.Picture picture)
        {
            Picture result = new Picture();

            result.Id = picture.Id;
            result.Path = picture.Path;
            result.PlanetId = picture.PlanetId;
            result.PictureName = picture.PictureName;

            return result;
        }

        public PlanetsBE.Picture ClonePicture(Picture picture)
        {
            PlanetsBE.Picture result = new PlanetsBE.Picture();

            result.Id = picture.Id;
            result.Path = picture.Path;
            result.PlanetId = picture.PlanetId;
            result.PictureName = picture.PictureName;

            return result;
        }
    }
}
