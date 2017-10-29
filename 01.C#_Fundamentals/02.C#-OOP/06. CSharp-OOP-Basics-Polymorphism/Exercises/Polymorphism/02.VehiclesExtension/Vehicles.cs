using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    abstract class Vehicles
    {
        private double fuelQuantity;
        private double littersConsumationPerKm;
        private double tankCapacity;

        public Vehicles(double fuelQuantity, double littersConsumationPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.LittersConsumationPerKm = littersConsumationPerKm;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                this.tankCapacity = value;
            }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
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

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:F2}";
        }
    }
}
