using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetsBE
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public float Mass { get; set; }
        public float TrackRadius { get; set; }
        public float DurationOfRoute { get; set; }
        public float TrackInclination { get; set; }
        public float Diameter { get; set; }
        public float Eccentricity { get; set; }
        public float DayLength { get; set; }
        public int Moons { get; set; }
        public int PlanetaryRings { get; set; }
        public int Atmospheres { get; set; }
        public int ProfilePicture { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}, Type: {Type}, Mass: {Mass}, TrackRadius: {TrackRadius}, DurationOfRoute: {DurationOfRoute}, "
                + $"TrackInclination: {TrackInclination}, Diameter: {Diameter}, Eccentricity: {Eccentricity}, DayLength: {DayLength}, "
                +$"Moons: {Moons}, PlanetaryRings: {PlanetaryRings}, Atmospheres: {Atmospheres}, ProfilePicture: {ProfilePicture}";
        }
    }
}
