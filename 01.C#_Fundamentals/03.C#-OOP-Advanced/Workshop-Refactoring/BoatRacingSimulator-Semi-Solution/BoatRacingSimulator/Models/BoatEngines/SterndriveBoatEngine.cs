using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatRacingSimulator.Models.BoatEngines
{
    class SterndriveBoatEngine : BoatEngine
    {
        private const int Multiplier = 7;

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

        public SterndriveBoatEngine(string model, int horsepower, int displacement) 
            : base(model, horsepower, displacement)
        {
        }
    }
}
