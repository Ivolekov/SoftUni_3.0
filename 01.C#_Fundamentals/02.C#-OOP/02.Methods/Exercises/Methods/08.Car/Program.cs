using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _08.Car
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine().Split();
            int speed = int.Parse(carArgs[0]);
            int fuel = int.Parse(carArgs[1]);
            int fuelEconomy = int.Parse(carArgs[2]);
            Car car = new Car(speed, fuel, fuelEconomy);
            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                switch (input[0])
                {
                    case "Travel":
                        car.Travel(double.Parse(input[1]));
                        break;
                    case "Refuel":
                        car.Refuel(double.Parse(input[1]));
                        break;
                    case "Distance":
                        car.Distance();
                        break;
                    case "Time":
                        car.Time();
                        break;
                    case "Fuel":
                        car.Fuel();
                        break;
                }
                input = Console.ReadLine().Split();
            }
        }
    }

    public class Car
    {
        public double speed;
        public double fuel;
        public double fuelEconomy;

        public double traveledDistance = 0;
        public int hour = 0;
        public int minutes = 0;

        public Car(double speed, double fuel, double fuelEconomy)
        {
            this.speed = speed;
            this.fuel = fuel;
            this.fuelEconomy = fuelEconomy;
        }

        public void Travel(double distance)
        {
            double minDistance = Math.Min((fuel / fuelEconomy) * speed, distance);
            traveledDistance += minDistance;
            fuel -= fuelEconomy * minDistance / speed;
            hour += (int)(minDistance / speed);
            minutes += (int)(minDistance % speed);
        }

        public void Refuel(double liter)
        {
            fuel += liter;
        }

        public void Distance()
        {
            Console.WriteLine($"Total distance: {traveledDistance:F1} kilometers");
        }

        public void Time()
        {
            Console.WriteLine($"Total time: {hour} hours and {minutes} minutes");
        }

        public void Fuel()
        {
            Console.WriteLine($"Fuel left: {fuel:F1} liters");
        }
    }
}

