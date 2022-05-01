using Firebase.Storage;
using System.IO;


namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        //Picture
        public string UploadPictureToFireBase(PlanetsBE.Picture picture)
        {
            var stream = File.Open(picture.Path, FileMode.Open);

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
        public string UploadPODToFireBase(string nasaUrl, string pictureName)
        {
            var stream = File.Open(nasaUrl, FileMode.Open);

            var task = new FirebaseStorage("planets-d4e9c.appspot.com")
            .Child("PictureOfTheDay")
            .Child(pictureName + ".jpg")
            .PutAsync(stream);


            var downloadUrl = task.TargetUrl;
            return downloadUrl;
        }

        public async void DeletePODFromFirebase(PictureOfTheDay pod)
        {
            int length = pod.Name.Length;
            var podName = pod.Name.Insert(length, ".jpg");

            await new FirebaseStorage("planets-d4e9c.appspot.com").Child("PictureOfTheDay").Child(podName).DeleteAsync();
        }

    }
}
