namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    class Yacht : Boat, IEngineHolder
    {
        private int cargoWeight;
        private IBoatEngine engine;

        public Yacht(string model, int weight, int cargoWeight, IBoatEngine engine)
            : base(model, weight)
        {
            this.cargoWeight = cargoWeight;
            this.Engine = engine;
        }

        public IBoatEngine Engine
        {
            get { return this.engine; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.engine = value;
            }
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, nameof(this.CargoWeight));
                this.cargoWeight = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.engine.Output - (this.Weight + this.CargoWeight) + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}
