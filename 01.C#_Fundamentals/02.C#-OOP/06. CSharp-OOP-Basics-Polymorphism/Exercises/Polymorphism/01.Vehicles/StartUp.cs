using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double litersQuantityCar = double.Parse(carInput[1]);
            double litterPerKmCar = double.Parse(carInput[2]);

            string[] truckInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double litersQuantityTruck = double.Parse(truckInput[1]);
            double litterPerKmTruck = double.Parse(truckInput[2]);

            Car car = new Car(litersQuantityCar, litterPerKmCar);
            Truck truck = new Truck(litersQuantityTruck, litterPerKmTruck);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = input[0].ToLower();
                string type = input[1].ToLower();

                switch (command)
                {
                    case "drive":
                        double distance = double.Parse(input[2]);
                        switch (type)
                        {
                            case "car":
                                car.Drive(distance);
                                break;
                            case "truck":
                                truck.Drive(distance);
                                break;
                        }
                        break;

                    case "refuel":
                        double litters = double.Parse(input[2]);
                        switch (type)
                        {
                            case "car":
                                car.Refuel(litters);
                                break;
                            case "truck":
                                truck.Refuel(litters);
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
