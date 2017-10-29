using MassDefect.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.ConsoleClient.cs
{
    using System.IO;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    public class Program
    {
        static void Main(string[] args)
        {
            MassDefectContext context = new MassDefectContext();
            //context.Database.Initialize(true);

            //ExportPlanetsWhichAreNotAnomalyOrigins(context);
            //ExportPeopleWichHaveNotBeenVictims(context);
            //ExportTopAnomaly(context);
        }

        private static void ExportTopAnomaly(MassDefectContext context)
        {
            var exportTopAnomaly = context.Anomalies
                .Where(a => a.Victims.Count > 0)
                .OrderBy(a=>a.Victims.Count)
                .Take(1)
                .Select(a => new
                {
                    id = a.Id,
                    originPlanet = a.OriginPlanet,
                    teleportPlanet = a.TeleportPlanet,
                    victimsCount = a.Victims.Count
                }).FirstOrDefault();
            var anomalyAsJson = JsonConvert.SerializeObject(exportTopAnomaly, Formatting.Indented);
            File.WriteAllText("../../anomaly.json", anomalyAsJson);
        }

        private static void ExportPeopleWichHaveNotBeenVictims(MassDefectContext context)
        {
            var exportPeople = context.Persons
                .Where(p => p.Anomalies.Count == 0)
                .Select(p => new
                {
                    name = p.Name,
                    homePlanetName = p.HomePlanet.Name
                });

            var peopleAsJson = JsonConvert.SerializeObject(exportPeople, Formatting.Indented);
            File.WriteAllText("../../people.json", peopleAsJson);
        }

        private static void ExportPlanetsWhichAreNotAnomalyOrigins(MassDefectContext context)
        {
            var exportPlanet = context.Planets
                .Where(planet => !planet.OriginAnomalies.Any())
                .Select(planet => new
                {
                    name = planet.Name
                });

            var planetAsJson = JsonConvert.SerializeObject(exportPlanet, Formatting.Indented);
            File.WriteAllText("../../planets.json", planetAsJson);
        }
    }
}
