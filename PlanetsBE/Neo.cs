using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsBE
{
    public class Neo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SerchDate { get; set; }
        //Minimmum estimation
        public float EstimatedDiameter { get; set; }
        public bool IsPotentiallyHazardousAsteroid { get; set; }
    }
}
