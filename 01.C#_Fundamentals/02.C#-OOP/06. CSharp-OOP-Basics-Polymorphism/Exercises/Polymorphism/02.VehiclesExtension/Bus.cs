using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    class Bus : Vehicles
    {
        public Bus(double fuelQuantity, double littersConsumationPerKm, double tankCapacity) 
            : base(fuelQuantity, littersConsumationPerKm, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if ((this.FuelQuantity + liters) > base.TankCapacity)
            {
                Console.WriteLine("Cannot fit fuel in tank");
            }
            else
            {
                base.FuelQuantity += liters;
            }

        }

        public void TravelWithPeople()
        {
            this.LittersConsumationPerKm += 1.4;
        }
    }
}
