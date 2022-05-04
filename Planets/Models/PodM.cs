using PlanetsBE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Models
{
    public class PodM
    {
        public PlanetsBL.PlanetsBl BlReference { get; set; }

        public List<PictureOfTheDay> Pods { get; set; }

        public PodM()
        {
            BlReference = new PlanetsBL.PlanetsBl();

           Pods = BlReference.GetPictureOfTheDays();
        }


    }
}
