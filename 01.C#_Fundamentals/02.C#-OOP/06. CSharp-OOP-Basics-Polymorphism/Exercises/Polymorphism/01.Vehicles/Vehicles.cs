using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    abstract class Vehicles
    {
        private double fuelQuantity;
        private double littersConsumationPerKm;
        private double distance;

        public Vehicles(double fuelQuantity, double littersConsumationPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.LittersConsumationPerKm = littersConsumationPerKm;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value;}
        }

        public virtual double LittersConsumationPerKm { get; set; }

        public void Drive(double distance)
        {
            double possibleDistance = this.FuelQuantity / this.LittersConsumationPerKm;
            if (distance <= possibleDistance)
            {
                this.FuelQuantity -= distance * this.LittersConsumationPerKm;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual double Refuel(double liters)
        {
            return this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:F2}";
        }
    }
}
