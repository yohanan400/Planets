using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetsBE;

namespace PlanetsBL
{
    public partial class PlanetsBl
    {
        public Planet GetPlanet(string name)
        {
            return DalReference.GetPlanetByName("Earth");
        }

        public List<Planet> GetAllPlanets()
        {
            return DalReference.GetAllPlanets();
        }
    }
}
