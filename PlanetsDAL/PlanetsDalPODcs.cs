using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public void AddPOD()
        {


            //var httpRequest = (HttpWebRequest)WebRequest.Create(url);


            //var httpResponse = httpRequest.GetResponse();

            
            //var url = "https://images-api.nasa.gov/search?q=paris";

            //using (WebClient client = new WebClient())
            //{
            //    Uri downloadURI = new Uri(url);

            //    var stream = client.DownloadString(downloadURI);
            //    dynamic jsonFile = JsonConvert.DeserializeObject(stream);
                
            //    var podUrl = jsonFile.collection.items.first.links.href;
            //}



            //TODO: CONNECT TO NASA API AND FILL PICTUREOFTHEDAY OBJECT AND UPLOAD IT TO DATABASE AND FIREBASE
            Uri uri = new Uri("https://api.nasa.gov/planetary/apod?api_key=Ge2ay3CtDiciZEJ3z1BAb0rQS9GElv8LIrntvwCJ");
            string firebaseUrl = UploadPODToFireBase("", "test");
            using (PlanetsEntities context = new PlanetsEntities())
            {
                context.PictureOfTheDays.Add(new PictureOfTheDay { URL = firebaseUrl /*TODO: THE REST FILL WITH NASA API*/}) ;
                context.SaveChanges();
            }
        }

        public PlanetsBE.PictureOfTheDay GetPictureOfTheDayById(int podId)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                return PodClone(context.PictureOfTheDays.FirstOrDefault(x => x.Id == podId));
            }
        }

        public List<PlanetsBE.PictureOfTheDay> GetAllPictureOfTheDay()
        {
            List<PlanetsBE.PictureOfTheDay> pod = new List<PlanetsBE.PictureOfTheDay>();
            using (PlanetsEntities context = new PlanetsEntities())
            {
                foreach (var item in context.PictureOfTheDays)
                {
                    pod.Add(PodClone(item));
                }

                return pod;
            }
        }

        public void UpdatePictureOfTheDay(PlanetsBE.PictureOfTheDay pictureOfTheDay)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                PictureOfTheDay result = context.PictureOfTheDays.FirstOrDefault(x => x.Id == pictureOfTheDay.Id);
                result = PodClone(pictureOfTheDay);

                context.SaveChanges();
            }
        }

        public void DeletePictureOfTheDay(PlanetsBE.PictureOfTheDay pictureOfTheDay)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {    
                PictureOfTheDay pod = context.PictureOfTheDays.FirstOrDefault(x => x.Id == pictureOfTheDay.Id);
                
                DeletePODFromFirebase(pod); 
                context.PictureOfTheDays.Remove(pod);

                context.SaveChanges();
            }
        }

        public PlanetsBE.PictureOfTheDay PodClone(PictureOfTheDay pod)
        {
            PlanetsBE.PictureOfTheDay result = new PlanetsBE.PictureOfTheDay();
            result.Id = pod.Id;
            result.Name = pod.Name;
            result.ReleaseDate = pod.ReleaseDate;
            result.Url = pod.URL;

            return result;
        }

        public PictureOfTheDay PodClone(PlanetsBE.PictureOfTheDay pod)
        {
            PictureOfTheDay result = new PictureOfTheDay();
            result.Id = pod.Id;
            result.Name = pod.Name;
            result.ReleaseDate = pod.ReleaseDate;
            result.URL = pod.Url;

            return result;
        }

    }
}
