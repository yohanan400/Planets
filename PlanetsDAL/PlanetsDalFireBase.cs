using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public string  UploadPictureToFireBase(PlanetsBE.Picture picture)
        {
            var stream = File.Open(picture.Path, FileMode.Open);
            // Construct FirebaseStorage with path to where you want to upload the
            //file and put it there
            var task = new FirebaseStorage("planets-d4e9c.appspot.com")
            .Child("Planets")
            .Child(picture.PictureName + ".jpg")
            .PutAsync(stream);

            // Await the task to wait until upload is completed and get the download url
            var downloadUrl =  task.TargetUrl;
            return downloadUrl;
        }

        public string UploadPODToFireBase(string nasaUrl, string pictureName)
        {
            var stream = File.Open(nasaUrl, FileMode.Open);
            // Construct FirebaseStorage with path to where you want to upload the
            //file and put it there
            var task = new FirebaseStorage("planets-d4e9c.appspot.com")
            .Child("PictureOfTheDay")
            .Child(pictureName + ".jpg")
            .PutAsync(stream);

            // Await the task to wait until upload is completed and get the download url
            var downloadUrl = task.TargetUrl;
            return downloadUrl;
        }

    }
}
