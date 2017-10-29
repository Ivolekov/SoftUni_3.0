namespace MassDefect.SeedXML
{
    using System.Data.Entity.Validation;
    using System.Xml.XPath;
    using Data;
    using MassDefect.Models;
    using System;
    using System.Xml.Linq;

    class Program
    {
        private const string NEW_ANOMALIES_ROUTE = "../../../datasets/new-anomalies.xml";
        static void Main()
        {
            var xml = XDocument.Load(NEW_ANOMALIES_ROUTE);
            var anomalies = xml.XPathSelectElements("anomalies/anomaly");

            var context = new MassDefectContext();
            foreach (var anomaly in anomalies)
            {
                ImportAnomalyAndVictims(anomaly, context);
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

        private static void ImportAnomalyAndVictims(XElement anomalyNode, MassDefectContext context)
        {
            var originPlanetName = anomalyNode.Attribute("origin-planet");
            var teleportPlanetName = anomalyNode.Attribute("teleport-planet");

            if (originPlanetName != null && teleportPlanetName != null)
            {
                var anomalyEntity = new Anomaly
                {
                    OriginPlanet = GetPlanetByName(originPlanetName.Value, context),
                    TeleportPlanet = GetPlanetByName(teleportPlanetName.Value, context)
                };

                if (anomalyEntity.OriginPlanet == null || anomalyEntity.TeleportPlanet == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }

                context.Anomalies.Add(anomalyEntity);
                Console.WriteLine("Successfully imported anomaly.");

                var victims = anomalyNode.XPathSelectElements("victims/victim");
                foreach (var victim in victims)
                {
                    ImportVictim(victim, context, anomalyEntity);
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid data.");
            }
        }

        private static void ImportVictim(XElement victimNode, MassDefectContext context, Anomaly anomaly)
        {
            var name = victimNode.Attribute("name");
            if (name == null)
            {
                Console.WriteLine("Error: Invalid data.");
            }
            else
            {
                var personEntity = GetPersonByName(name.Value, context);

                if (personEntity == null)
                {
                    Console.WriteLine("Error: Invalid data.");
                }
                else
                {
                    anomaly.Victims.Add(personEntity);
                }
            }
        }

        private static Person GetPersonByName(string value, MassDefectContext context)
        {
            var persons = context.Persons;
            foreach (var person in persons)
            {
                if (person.Name == value)
                {
                    return person;
                }
            }
            return null;
        }

        private static Planet GetPlanetByName(string value, MassDefectContext context)
        {
            var planets = context.Planets;

            foreach (var planet in planets)
            {
                if (planet.Name == value)
                {
                    return planet;
                }
            }
            return null;
        }
    }
}
