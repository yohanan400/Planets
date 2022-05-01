using Firebase.Storage;
using System;
using System.IO;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
      
        //Picture
        public string UploadPictureToFireBase(PlanetsBE.Picture picture)
        {
            FileStream stream = File.Open(picture.Path, FileMode.Open);

            var task = new FirebaseStorage("planets-d4e9c.appspot.com")
            .Child("Planets")
            .Child(picture.PictureName + ".jpg")
            .PutAsync(stream);


            // Convert the URL from Json file to image downloadable file
            string downloadUrl = task.TargetUrl;
            string newPath = downloadUrl.Replace("?name=", "/");
            return newPath + "?alt=media&token=5ecc2fe8-72fb-40d1-bd98-1656389dca15";
        }

        public async void DeletePictureFromFirebase(Picture picture)
        {
            int length = picture.PictureName.Length;
            var pictureName = picture.PictureName.Insert(length, ".jpg");

            var client = new FirebaseStorage("planets-d4e9c.appspot.com");
            var child = client.Child("Planets").Child(pictureName);

            await child.DeleteAsync();
        }

        //PictureOfTheDay
        public string UploadPODToFireBase(string url, string title)
        {
            using (WebClient client = new WebClient())
            {
                MemoryStream ms = new MemoryStream(client.DownloadData(url));

                var task = new FirebaseStorage("planets-d4e9c.appspot.com")
                    .Child("PictureOfTheDay")
                    .Child(title + ".jpg")
                    .PutAsync(ms);

                var downloadUrl = task.TargetUrl;
                string newPath = downloadUrl.Replace("?name=", "/");
                return newPath + "?alt=media&token=5ecc2fe8-72fb-40d1-bd98-1656389dca15";
            }
        }

        public async void DeletePODFromFirebase(PictureOfTheDay pod)
        {
            int length = pod.Title.Length;
            var podName = pod.Title.Insert(length, ".jpg");

            await new FirebaseStorage("planets-d4e9c.appspot.com").Child("PictureOfTheDay").Child(podName).DeleteAsync();
        }

    }
}
