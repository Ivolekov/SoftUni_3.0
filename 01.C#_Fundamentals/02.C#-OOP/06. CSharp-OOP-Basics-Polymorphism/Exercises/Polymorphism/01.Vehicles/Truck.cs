using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double littersConsumationPerKm)
            : base(fuelQuantity, littersConsumationPerKm)
        {
        }

        public override double LittersConsumationPerKm
        {
            get { return base.LittersConsumationPerKm; }

            set { base.LittersConsumationPerKm = value + 1.6; }
        }

        public override double Refuel(double liters)
        {
            return base.FuelQuantity += liters * 0.95;
        }
    }
}
