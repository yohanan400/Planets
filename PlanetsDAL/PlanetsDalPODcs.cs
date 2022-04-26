using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public void AddPOD()
        {
            //TODO: CONNECT TO NASA API AND FILL PICTUREOFTHEDAY OBJECT AND UPLOAD IT TO DATABASE AND FIREBASE
            string firebaseUrl = UploadPODToFireBase("", "");
            using (PlanetsEntities context = new PlanetsEntities())
            {
                context.PictureOfTheDays.Add(new PictureOfTheDay { URL = firebaseUrl /*TODO: THE REST FILL WITH NASA API*/}) ;
                context.SaveChanges();
            }
        }
    }
}
