using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planets.Models
{
    public class NeoM
    {
        PlanetsBL.PlanetsBl BlReference;

        public List<PlanetsBE.Neo> neos;

        public NeoM()
        {
            BlReference = new PlanetsBL.PlanetsBl();
            neos = new List<PlanetsBE.Neo>(BlReference.GetNeosList());
        }

    }
}
