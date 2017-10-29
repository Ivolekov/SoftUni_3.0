namespace MassDefect.SeedJSON
{
    using Data;
    using Models;
    using Models.DTO;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.IO;
    public class Program
    {
        private const string SOLAR_SYSTEMS_ROUTE = "../../../datasets/solar-systems.json";

        private const string STARS_ROUTE = "../../../datasets/stars.json";

        private const string PLANET_ROUTE = "../../../datasets/planets.json";

        private const string PERSON_ROUTE = "../../../datasets/persons.json";

        private const string ANOMALY_ROUTE = "../../../datasets/anomalies.json";

        private const string ANOMALY_VCTIMS_ROUTE = "../../../datasets/anomaly-victims.json";
        static void Main(string[] args)
        {
            ImportSolarSystem();
            ImportStars();
            ImportPlanets();
            ImportPersons();
            ImportAnomalies();
            ImportAnomalyVictims();
        }

        private static void ImportAnomalyVictims()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(ANOMALY_VCTIMS_ROUTE);
            var anomalyVictims = JsonConvert.DeserializeObject<IEnumerable<AnomalyVictimDTO>>(json);

            foreach (var anomalyVictim in anomalyVictims)
            {
                if (anomalyVictim.Id == null || anomalyVictim.Person == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }
                var anomalyEntity = GetAnomalyById(anomalyVictim.Id, context);
                var personEntity = GetPersonByName(anomalyVictim.Person, context);

                if (anomalyEntity == null || personEntity == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                anomalyEntity.Victims.Add(personEntity);
            }

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ms in ex.EntityValidationErrors)
                {
                    foreach (var m in ms.ValidationErrors)
                    {
                        Console.WriteLine(m.ErrorMessage);
                    }
                }
            }
        }

        private static void ImportAnomalies()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(ANOMALY_ROUTE);
            var anomalies = JsonConvert.DeserializeObject<IEnumerable<AnomalyDTO>>(json);

            foreach (var anomaly in anomalies)
            {
                var anomalyEntity = new Anomaly
                {
                    OriginPlanet = GetPlanetByName(anomaly.OriginPlanet, context),
                    TeleportPlanet = GetPlanetByName(anomaly.TeleportPlanet, context)
                };

                if (anomalyEntity.OriginPlanet == null || anomalyEntity.TeleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Anomalies.Add(anomalyEntity);
                Console.WriteLine("Successfully imported anomaly.");
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ms in ex.EntityValidationErrors)
                {
                    foreach (var m in ms.ValidationErrors)
                    {
                        Console.WriteLine(m.ErrorMessage);
                    }
                }
            }
        }

        private static void ImportPersons()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PERSON_ROUTE);
            var persons = JsonConvert.DeserializeObject<IEnumerable<PersonDTO>>(json);

            foreach (var person in persons)
            {
                if (person.Name == null || person.HomePlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var personEntity = new Person
                {
                    Name = person.Name,
                    HomePlanet = GetPlanetByName(person.HomePlanet, context)
                };

                if (personEntity.HomePlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Persons.Add(personEntity);
                Console.WriteLine($"Successfully imported Person {personEntity.Name} with Home Planet {personEntity.HomePlanet.Name}.");
            }

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ms in ex.EntityValidationErrors)
                {
                    foreach (var m in ms.ValidationErrors)
                    {
                        Console.WriteLine(m.ErrorMessage);
                    }
                }
            }
        }

        private static void ImportPlanets()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(PLANET_ROUTE);
            var planets = JsonConvert.DeserializeObject<IEnumerable<PlanetDTO>>(json);

            foreach (var planet in planets)
            {
                if (planet.Name == null || planet.SolarSystem == null || planet.Sun == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var planetEntity = new Planet
                {
                    Name = planet.Name,
                    SolarSystem = GetSolarSystemByName(planet.SolarSystem, context),
                    Sun = GetStarByName(planet.Sun, context)

                };

                if (planetEntity.SolarSystem == null || planetEntity.Sun == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Planets.Add(planetEntity);
                Console.WriteLine($"Successfully imported Planet {planetEntity.Name}.");
            }
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ms in ex.EntityValidationErrors)
                {
                    foreach (var m in ms.ValidationErrors)
                    {
                        Console.WriteLine(m.ErrorMessage);
                    }
                }
            }
        }

        private static void ImportStars()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(STARS_ROUTE);
            var stars = JsonConvert.DeserializeObject<IEnumerable<StarDTO>>(json);

            foreach (var star in stars)
            {
                if (star.Name == null || star.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var starEntity = new Star
                {
                    Name = star.Name,
                    SolarSystem = GetSolarSystemByName(star.SolarSystem, context)

                };

                if (starEntity.SolarSystem == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                context.Stars.Add(starEntity);
                Console.WriteLine($"Successfully imported Star {starEntity.Name}.");
            }

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ms in ex.EntityValidationErrors)
                {
                    foreach (var m in ms.ValidationErrors)
                    {
                        Console.WriteLine(m.ErrorMessage);
                    }
                }
            }
        }

        private static void ImportSolarSystem()
        {
            var context = new MassDefectContext();
            var json = File.ReadAllText(SOLAR_SYSTEMS_ROUTE);
            var solarSystems = JsonConvert.DeserializeObject<IEnumerable<SolarSystemDTO>>(json);

            foreach (var solarSystem in solarSystems)
            {
                if (solarSystem.Name == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                    continue;
                }

                var solarSystemEntity = new SolarSystem
                {
                    Name = solarSystem.Name
                };

                context.SolarSystems.Add(solarSystemEntity);
                Console.WriteLine($"Successfully imported Solar System {solarSystemEntity.Name}.");
            }

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var ms in ex.EntityValidationErrors)
                {
                    foreach (var m in ms.ValidationErrors)
                    {
                        Console.WriteLine(m.ErrorMessage);
                    }
                }
            }
        }

        private static Planet GetPlanetByName(string homePlanet, MassDefectContext context)
        {
            var planets = context.Planets;

            foreach (var planet in planets)
            {
                if (planet.Name == homePlanet)
                {
                    return planet;
                }
            }
            return null;
        }

        private static Star GetStarByName(string sun, MassDefectContext context)
        {
            var suns = context.Stars;

            foreach (var star in suns)
            {
                if (star.Name == sun)
                {
                    return star;
                }
            }
            return null;
        }

        private static SolarSystem GetSolarSystemByName(string solarSystem, MassDefectContext context)
        {
            var solarSystemNames = context.SolarSystems;

            foreach (var solarSystemName in solarSystemNames)
            {
                if (solarSystemName.Name == solarSystem)
                {
                    return solarSystemName;
                }
            }
            return null;
        }

        private static Person GetPersonByName(string personName, MassDefectContext context)
        {
            var persons = context.Persons;
            foreach (var person in persons)
            {
                if (person.Name == personName)
                {
                    return person;
                }
            }
            return null;
        }

        private static Anomaly GetAnomalyById(string id, MassDefectContext context)
        {
            var anomalies = context.Anomalies;
            foreach (var anomaly in anomalies)
            {
                if (anomaly.Id.ToString() == id)
                {
                    return anomaly;
                }
            }
            return null;
        }
    }
}
