using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public void AddPicture(PlanetsBE.Picture picture)
        {
            string firebasePath = UploadPictureToFireBase(picture);

            using (PlanetsEntities context = new PlanetsEntities())
            {
                context.Pictures.Add(new Picture { PlanetId = picture.PlanetId, Path = firebasePath });
                context.SaveChanges();
            }
        }
    }
}
