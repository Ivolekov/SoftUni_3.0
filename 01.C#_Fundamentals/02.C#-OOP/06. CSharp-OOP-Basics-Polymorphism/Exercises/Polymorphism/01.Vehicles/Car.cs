using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    class Car : Vehicles
    {
        public Car(double fuelQuantity, double littersConsumationPerKm)
            : base(fuelQuantity, littersConsumationPerKm)
        {
        }

        public override double LittersConsumationPerKm
        {
            get { return base.LittersConsumationPerKm; }

            set { base.LittersConsumationPerKm = value + 0.9; }
        }
    }
}
