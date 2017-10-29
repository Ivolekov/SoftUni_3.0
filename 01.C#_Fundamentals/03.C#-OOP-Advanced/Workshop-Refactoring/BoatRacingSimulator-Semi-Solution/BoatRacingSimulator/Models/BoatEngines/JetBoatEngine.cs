namespace BoatRacingSimulator.Models.BoatEngines
{
    class JetBoatEngine : BoatEngine
    {
        private const int Multiplier = 5;
                            
        public override int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * Multiplier) + this.Displacement;
                return this.CachedOutput;
            }
        }

        public JetBoatEngine(string model, int horsepower, int displacement)
            : base(model, horsepower, displacement)
        {
        }
    }
}