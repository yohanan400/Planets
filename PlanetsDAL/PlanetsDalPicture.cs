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
