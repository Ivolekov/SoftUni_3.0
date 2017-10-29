using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars= new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                decimal fuelAmount = decimal.Parse(input[1]);
                decimal fuelCostPerKilometer = decimal.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelCostPerKilometer);
                cars.Add(car);
            }
            string driveCommand = Console.ReadLine();
            while (driveCommand!="End")
            {
                string[] driveCommandArgs = driveCommand.Split();
                string carModel = driveCommandArgs[1];
                int amountOfKm = int.Parse(driveCommandArgs[2]);
                Car carToDrive = cars.First(c => c.model == carModel);
                carToDrive.Drive(amountOfKm);
                driveCommand = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1:F2} {2}",car.model, car.fuelAmount, car.distance);
            }
        }
    }

    public class Car
    {
        public string model;
        public decimal fuelAmount;
        public decimal fuelCostPerKilometer;
        public int distance;

        public Car(string model, decimal fuelAmount, decimal fuelCostPerKilometer)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelCostPerKilometer = fuelCostPerKilometer;
            this.distance = 0;
        }

        public void Drive(int amountOfKm)
        {
            if (amountOfKm<=this.fuelAmount/this.fuelCostPerKilometer)
            {
                this.distance += amountOfKm;
                this.fuelAmount -= this.fuelCostPerKilometer*amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
