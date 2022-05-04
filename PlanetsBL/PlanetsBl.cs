using PlanetsBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsBL
{
    public partial class PlanetsBl
    {
        public PlanetsDAL.PlanetsDal DalReference { get; set; }
        public PlanetsBl()
        {
            DalReference = new PlanetsDAL.PlanetsDal();

            //One time download data
            //DalReference.AddAllPODToDB();

            //One time download data
            //DalReference.AddBetweenDatesNeosToDB(new DateTime(2022, 5, 1), DateTime.Now);
        }

        public List<PictureOfTheDay> GetPictureOfTheDays()
        {
            return DalReference.GetAllPictureOfTheDay();
        }
    }
}
