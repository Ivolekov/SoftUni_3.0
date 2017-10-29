namespace BoatRacingSimulator.Models.BoatEngines
{
    using BoatRacingSimulator.Interfaces;
    using BoatRacingSimulator.Utility;

    internal abstract class BoatEngine : IBoatEngine
    {                   
        private string model;    
        private int horsepower;      
        private int displacement;

        public BoatEngine(string model, int horsepower, int displacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.Displacement = displacement;
        }

        public abstract int Output { get; }
                                 
        protected int CachedOutput { get; set; }

        protected int Horsepower
        {
            get
            {
                return this.horsepower;
            }

            set
            {
                Validator.ValidatePropertyValue(value, nameof(this.Horsepower));
                this.horsepower = value;
            }
        }

        protected int Displacement
        {
            get
            {
                return this.displacement;
            }

            set
            {
                Validator.ValidatePropertyValue(value, nameof(this.Displacement));
                this.displacement = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                Validator.ValidateModelLength(value, Constants.MinBoatEngineModelLength);
                this.model = value;
            }
        }
    }
}
