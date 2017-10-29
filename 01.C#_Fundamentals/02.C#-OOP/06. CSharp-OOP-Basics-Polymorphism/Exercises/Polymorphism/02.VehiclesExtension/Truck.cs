using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    class Truck : Vehicles
    {
        public Truck(double fuelQuantity, double littersConsumationPerKm, double tankCapacity)
            : base(fuelQuantity, littersConsumationPerKm, tankCapacity)
        {
        }

        public override double LittersConsumationPerKm
        {
            get { return base.LittersConsumationPerKm; }

            set { base.LittersConsumationPerKm = value + 1.6; }
        }

        public override void Refuel(double liters)
        {
            base.FuelQuantity += liters * 0.95;
        }
    }
}
