namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    class Yacht : Boat, IEngineHelder
    {
        private int cargoWeight;
        IBoatEngine engine;

        public Yacht(string model, int weight, int cargoWeight, IBoatEngine engine)
            : base(model, weight)
        {
            this.CargoWeight = cargoWeight;
            this.Engine = engine;
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, "Cargo Weight");
                this.cargoWeight = value;
            }
        }

        internal IBoatEngine Engine
        {
            get
            {
                return this.engine;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.engine = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.engine.Output - (this.Weight + this.CargoWeight) + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}
