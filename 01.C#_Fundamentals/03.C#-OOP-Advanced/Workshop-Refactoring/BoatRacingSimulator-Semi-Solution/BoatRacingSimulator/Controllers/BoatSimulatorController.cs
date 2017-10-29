namespace BoatRacingSimulator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BoatRacingSimulator.Database;
    using BoatRacingSimulator.Enumerations;
    using BoatRacingSimulator.Exceptions;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Models;
    using BoatRacingSimulator.Models.BoatEngines;
    using BoatRacingSimulator.Models.Boats;
    using BoatRacingSimulator.Utility;

    public class BoatSimulatorController : IBoatSimulatorController
    {
        public BoatSimulatorController(BoatSimulatorDatabase database, IRace currentRace)
        {
            this.Database = database;
            this.CurrentRace = currentRace;
        }

        public BoatSimulatorController() : this(new BoatSimulatorDatabase(), null)
        {
        }

        public IRace CurrentRace { get; private set; }

        public BoatSimulatorDatabase Database { get; private set; }

        public string CreateBoatEngine(string model, int horsepower, int displacement, EngineType engineType)
        {
            IBoatEngine engine;
            switch (engineType)
            {
                case EngineType.Jet:
                    engine = new JetBoatEngine(model, horsepower, displacement);
                    break;
                case EngineType.Sterndrive:
                    engine = new SterndriveBoatEngine(model, horsepower, displacement);
                    break;
                default:
                    throw new NotImplementedException();
            }

            this.Database.Engines.Add(engine);
            return string.Format(
                "Engine model {0} with {1} HP and displacement {2} cm3 created successfully.",
                model,
                horsepower,
                displacement);
        }

        public string CreateRowBoat(string model, int weight, int oars)
        {
            IBoat boat = new RowBoat(model, weight, oars);
            this.Database.Boats.Add(boat);
            return string.Format("Row boat with model {0} registered successfully.", model);
        }

        public string CreateSailBoat(string model, int weight, int sailEfficiency)
        {
            IBoat boat = new SailBoat(model, weight, sailEfficiency);
            this.Database.Boats.Add(boat);
            return string.Format("Sail boat with model {0} registered successfully.", model);
        }

        public string CreatePowerBoat(string model, int weight, string firstEngineModel, string secondEngineModel)
        {
            IBoatEngine firstBoatEngine = this.Database.Engines.GetItem(firstEngineModel);
            IBoatEngine secondBoatEngine = this.Database.Engines.GetItem(secondEngineModel);
            IBoat boat = new PowerBoat(model, weight, firstBoatEngine, secondBoatEngine);
            this.Database.Boats.Add(boat);
            return string.Format("Power boat with model {0} registered successfully.", model);
        }

        public string CreateYacht(string model, int weight, string engineModel, int cargoWeight)
        {
            IBoatEngine boatEngine = this.Database.Engines.GetItem(engineModel);
            IBoat boat = new Yacht(model, weight, cargoWeight, boatEngine);
            this.Database.Boats.Add(boat);
            return string.Format("Yacht with model {0} registered successfully.", model);
        }

        public string OpenRace(int distance, int windSpeed, int oceanCurrentSpeed, bool allowsMotorboats)
        {
            IRace race = new Race(distance, windSpeed, oceanCurrentSpeed, allowsMotorboats);
            this.ValidateRaceIsEmpty();
            this.CurrentRace = race;
            return
                string.Format(
                    "A new race with distance {0} meters, wind speed {1} m/s and ocean current speed {2} m/s has been set.",
                    distance, windSpeed, oceanCurrentSpeed);
        }

        public string SignUpBoat(string model)
        {
            IBoat boat = this.Database.Boats.GetItem(model);
            this.ValidateRaceIsSet();
            if (!this.CurrentRace.AllowsMotorboats && boat is IEngineHelder)
            {
                throw new ArgumentException(Constants.IncorrectBoatTypeMessage);
            }
            this.CurrentRace.AddParticipant(boat);
            return string.Format("Boat with model {0} has signed up for the current Race.", model);
        }

        public string StartRace()
        {
            this.ValidateRaceIsSet();
            var participants = this.CurrentRace.GetParticipants();
            if (participants.Count < 3)
            {
                throw new InsufficientContestantsException(Constants.InsufficientContestantsMessage);
            }

            var orderedFinishinBoats = participants.Where(x => x.CalculateRaceSpeed(this.CurrentRace) > 0)
                .OrderByDescending(x => x.CalculateRaceSpeed(this.CurrentRace))
                .Concat(participants.Where(x => x.CalculateRaceSpeed(this.CurrentRace) <= 0))
                .Take(3)
                .ToList();

            var result = new StringBuilder();

            for (int i = 0; i < orderedFinishinBoats.Count; i++)
            {
                var speed = orderedFinishinBoats[i].CalculateRaceSpeed(this.CurrentRace);
                var time = this.CurrentRace.Distance / speed;

                result.AppendLine(string.Format(
               "{0} place: {1} Model: {2} Time: {3}",
               (Postiotions)i,
               orderedFinishinBoats[i].GetType().Name,
               orderedFinishinBoats[i].Model,
               time <= 0 ? "Did not finish!" : time.ToString("0.00") + " sec"));
            }

            this.CurrentRace = null;


            return result.ToString().Trim();
        }

        public string GetStatistic()
        {
            //TODO Bonus Task Implement me
            throw new NotImplementedException();
        }

        private KeyValuePair<double, IBoat> FindFastest(IList<IBoat> participants)
        {
            double bestTime = double.MaxValue;
            IBoat winner = null;
            foreach (var participant in participants)
            {
                var speed = participant.CalculateRaceSpeed(this.CurrentRace);
                var time = this.CurrentRace.Distance / speed;
                if (time < bestTime && time > 0)
                {
                    bestTime = time;
                    winner = participant;
                }
            }

            return new KeyValuePair<double, IBoat>(bestTime, winner);
        }

        private void ValidateRaceIsSet()
        {
            if (this.CurrentRace == null)
            {
                throw new NoSetRaceException(Constants.NoSetRaceMessage);
            }
        }

        private void ValidateRaceIsEmpty()
        {
            if (this.CurrentRace != null)
            {
                throw new RaceAlreadyExistsException(Constants.RaceAlreadyExistsMessage);
            }
        }
    }
}
