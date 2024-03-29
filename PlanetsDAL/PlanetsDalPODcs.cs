﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var url = "https://api.nasa.gov/planetary/apod?api_key=Ge2ay3CtDiciZEJ3z1BAb0rQS9GElv8LIrntvwCJ";

            using (WebClient client = new WebClient())
            {
                //Download Json file
                Uri downloadURI = new Uri(url);
                var stream = client.DownloadString(downloadURI);
                dynamic jsonFile = JsonConvert.DeserializeObject(stream);

                //Retrive the url of image from Json file
                var podUrl = (string)jsonFile.hdurl;

                //Upload image to firebase
                string firebaseUrl = UploadPODToFireBase(podUrl, (string)jsonFile.title);


                var newPod = new PictureOfTheDay
                {
                    URL = firebaseUrl,
                    Title = (string)jsonFile.title,
                    Explanation = (string)jsonFile.explanation,
                    ReleaseDate = (DateTime)jsonFile.date
                };
                using (PlanetsEntities context = new PlanetsEntities())
                {
                    context.PictureOfTheDays.Add(newPod);
                    context.SaveChanges();
                }
            }
        }

        public void DownloadPODsToDB(DateTime start, DateTime end)
        {
            var url = $"https://api.nasa.gov/planetary/apod?start_date={start.GetDateTimeFormats()[7]}&end_date={end.GetDateTimeFormats()[7]}&api_key=Ge2ay3CtDiciZEJ3z1BAb0rQS9GElv8LIrntvwCJ";

            using (WebClient client = new WebClient())
            {
                //Download Json file
                Uri downloadURI = new Uri(url);
                var stream = client.DownloadString(downloadURI);

                List<PictureOfTheDay> pods = new List<PictureOfTheDay>();
                JArray obj = JArray.Parse(stream);

                foreach (var item in obj.Value<JToken>())
                {
                    //Retrive the url of image from Json file
                    var podUrl = (string)item["hdurl"];

                    //Upload image to firebase
                    string firebaseUrl = UploadPODToFireBase(podUrl, (string)item["title"]);


                    pods.Add(new PictureOfTheDay
                                 {
                                     URL = firebaseUrl,
                                     Title = (string)item["title"],
                                     Explanation = (string)item["explanation"],
                                     ReleaseDate = (DateTime)item["date"]
                                 }
                    );
                }

                using (PlanetsEntities context = new PlanetsEntities())
                {
                    context.PictureOfTheDays.AddRange(pods);
                    context.SaveChanges();
                }
            }
        }

        public PlanetsBE.PictureOfTheDay GetPictureOfTheDayByDate(DateTime date)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                return PodClone(context.PictureOfTheDays.FirstOrDefault(x => x.ReleaseDate == date));
            }
        }

        public List<PlanetsBE.PictureOfTheDay> GetAllPictureOfTheDay()
        {
            List<PlanetsBE.PictureOfTheDay> pods = new List<PlanetsBE.PictureOfTheDay>();
            using (PlanetsEntities context = new PlanetsEntities())
            {
                foreach (var item in context.PictureOfTheDays)
                {
                    pods.Add(PodClone(item));
                }

                return pods;
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
            result.Title = pod.Title;
            result.ReleaseDate = pod.ReleaseDate;
            result.Url = pod.URL;
            result.Explanation = pod.Explanation;

            return result;
        }

        public PictureOfTheDay PodClone(PlanetsBE.PictureOfTheDay pod)
        {
            PictureOfTheDay result = new PictureOfTheDay();
            result.Id = pod.Id;
            result.Title = pod.Title;
            result.ReleaseDate = pod.ReleaseDate;
            result.URL = pod.Url;
            result.Explanation = pod.Explanation;

            return result;
        }

    }
}
