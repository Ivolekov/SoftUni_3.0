using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehiclesExtension
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double litersQuantityCar = double.Parse(carInput[1]);
            double litterPerKmCar = double.Parse(carInput[2]);
            double tankCapacityCar = double.Parse(carInput[3]);

            string[] truckInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double litersQuantityTruck = double.Parse(truckInput[1]);
            double litterPerKmTruck = double.Parse(truckInput[2]);
            double tankCapacityTruck = double.Parse(truckInput[3]);

            string[] busInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double litersQuantityBus = double.Parse(busInput[1]);
            double litterPerKmBus = double.Parse(busInput[2]);
            double tankCapacityBus = double.Parse(busInput[3]);

            Car car = new Car(litersQuantityCar, litterPerKmCar, tankCapacityCar);
            Truck truck = new Truck(litersQuantityTruck, litterPerKmTruck, tankCapacityTruck);
            Bus bus = new Bus(litersQuantityBus, litterPerKmBus, tankCapacityBus);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = input[0].ToLower();
                string type = input[1].ToLower();

                switch (command)
                {
                    case "driveempty":
                        double distanceEmptyBus = double.Parse(input[2]);
                        bus.Drive(distanceEmptyBus);
                        break;

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
                            case "bus":
                                bus.TravelWithPeople();
                                bus.Drive(distance);
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
                            case "bus":
                                bus.Refuel(litters);
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
