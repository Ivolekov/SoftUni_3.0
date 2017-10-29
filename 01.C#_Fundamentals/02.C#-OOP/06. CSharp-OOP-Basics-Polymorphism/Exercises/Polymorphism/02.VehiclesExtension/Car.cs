using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    class Car : Vehicles
    {
        public Car(double fuelQuantity, double littersConsumationPerKm, double tankCapacity)
            : base(fuelQuantity, littersConsumationPerKm, tankCapacity)
        {
        }

        public override double LittersConsumationPerKm
        {
            get { return base.LittersConsumationPerKm; }

            set { base.LittersConsumationPerKm = value + 0.9; }
        }

        public override void Refuel(double liters)
        {
            if ((this.FuelQuantity + liters) > base.TankCapacity)
            {
                Console.WriteLine("Cannot fit fuel in tank");
            }
            else
            {
                base.FuelQuantity+=liters;
            }
            
        }
    }
}
