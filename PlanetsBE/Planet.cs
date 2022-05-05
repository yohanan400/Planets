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
        public double Mass { get; set; }
        public double EquatorialRadius { get; set; }
        public double DurationOfRoute { get; set; }
        public double TrackInclination { get; set; }
        public double Diameter { get; set; }
        public double Eccentricity { get; set; }
        public double DayLength { get; set; }
        public int Moons { get; set; }
        public int PlanetaryRings { get; set; }
        public string Atmospheres { get; set; }
        public string ProfilePictureURL { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name}, Mass: {Mass}, TrackRadius: {EquatorialRadius}, DurationOfRoute: {DurationOfRoute}, "
                + $"TrackInclination: {TrackInclination}, Diameter: {Diameter}, Eccentricity: {Eccentricity}, DayLength: {DayLength}, "
                +$"Moons: {Moons}, PlanetaryRings: {PlanetaryRings}, Atmospheres: {Atmospheres}, ProfilePictureURL: {ProfilePictureURL}";
        }
    }
}
