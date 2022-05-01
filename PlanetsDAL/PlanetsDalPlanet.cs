using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PlanetsBE;

namespace PlanetsDAL
{
    public partial class PlanetsDal
    {
        public void AddPlanet(PlanetsBE.Planet planet, PlanetsBE.Picture picture)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                //Update the profile picture of the planet to DB and Firebase
                int picId = context.Pictures.Add(ClonePicture(picture)).Id;
                planet.ProfilePicture = picId;
                UploadPictureToFireBase(picture);

                //Update the planet to DB
                context.Planets.Add(PlanetsClone(planet));
                context.SaveChanges();
            }
        }

        public PlanetsBE.Planet GetPlanetByName(string name)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                PlanetsBE.Planet planet = PlanetsClone(context.Planets.FirstOrDefault(x => x.Name == name));
                return planet;
            }
        }

        public List<PlanetsBE.Planet> GetAllPlanets()
        {

            using (PlanetsEntities context = new PlanetsEntities())
            {
                List<PlanetsBE.Planet> planets = new List<PlanetsBE.Planet>();
                foreach (var item in context.Planets)
                {
                    planets.Add(PlanetsClone(item));
                }
                return planets;
            }

        }
        
        public void UpdatePlanetByName(PlanetsBE.Planet planet)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                Planet newPlanet = context.Planets.FirstOrDefault(x => x.Name == planet.Name);
                PlanetsClone(newPlanet, planet);
                
                context.SaveChanges(); 
            }
        }

        public void DeletePlanetByName(string name)
        {
            using (PlanetsEntities context = new PlanetsEntities())
            {
                Planet planet = context.Planets.FirstOrDefault(x => x.Name == name);
                context.Planets.Remove(planet);
                
                context.SaveChanges();
            }
        }

        public Planet PlanetsClone(PlanetsBE.Planet planet)
        {
            Planet newPlanet = new Planet();

            newPlanet.Name = planet.Name;
            newPlanet.Type = planet.Type;
            newPlanet.mass = planet.Mass;
            newPlanet.TrackRadius = planet.TrackRadius;
            newPlanet.DurationOfRoute = planet.DurationOfRoute;
            newPlanet.TrackInclination = planet.TrackInclination;
            newPlanet.Diameter = planet.Diameter;
            newPlanet.Eccentricity = planet.Eccentricity;
            newPlanet.DayLength = planet.DayLength;
            newPlanet.Moons = planet.Moons;
            newPlanet.PlanetaryRings = planet.PlanetaryRings;
            newPlanet.Atmosphere = planet.Atmospheres;
            newPlanet.ProfilePicture = planet.ProfilePicture;

            return newPlanet;
        }

        public PlanetsBE.Planet PlanetsClone(Planet planet)
        {
            PlanetsBE.Planet newPlanet = new PlanetsBE.Planet();

            newPlanet.Id = planet.Id;
            newPlanet.Name = planet.Name;
            newPlanet.Type = planet.Type;
            newPlanet.Mass = planet.mass;
            newPlanet.TrackRadius = planet.TrackRadius;
            newPlanet.DurationOfRoute = planet.DurationOfRoute;
            newPlanet.TrackInclination = planet.TrackInclination;
            newPlanet.Diameter = planet.Diameter;
            newPlanet.Eccentricity = planet.Eccentricity;
            newPlanet.DayLength = planet.DayLength;
            newPlanet.Moons = planet.Moons;
            newPlanet.PlanetaryRings = planet.PlanetaryRings;
            newPlanet.Atmospheres = planet.Atmosphere;
            newPlanet.ProfilePicture = planet.ProfilePicture;

            return newPlanet;
        }

        public void PlanetsClone(Planet newPlanet, PlanetsBE.Planet planet)
        {
            newPlanet.Name = planet.Name;
            newPlanet.Type = planet.Type;
            newPlanet.mass = planet.Mass;
            newPlanet.TrackRadius = planet.TrackRadius;
            newPlanet.DurationOfRoute = planet.DurationOfRoute;
            newPlanet.TrackInclination = planet.TrackInclination;
            newPlanet.Diameter = planet.Diameter;
            newPlanet.Eccentricity = planet.Eccentricity;
            newPlanet.DayLength = planet.DayLength;
            newPlanet.Moons = planet.Moons;
            newPlanet.PlanetaryRings = planet.PlanetaryRings;
            newPlanet.Atmosphere = planet.Atmospheres;
            newPlanet.ProfilePicture = planet.ProfilePicture;
        }
    }
}
