using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetsBE;

namespace Planets.Models
{
    public class PlanetM
    {
        PlanetsBL.PlanetsBl blReference;

        public Planet currentPlanet { get; set; }

        public List<Planet> planets { get; set; }

        string name;

        public PlanetM()
        {
            blReference = new PlanetsBL.PlanetsBl();
            currentPlanet = blReference.GetPlanet(name);
            planets = blReference.GetAllPlanets();
        }
    }
}
