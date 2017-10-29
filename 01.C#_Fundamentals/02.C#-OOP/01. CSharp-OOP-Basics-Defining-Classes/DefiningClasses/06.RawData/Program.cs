using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string carModel = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                double tire1Pressure = Double.Parse(carInfo[5]);
                int tire1Age = int.Parse(carInfo[6]);
                double tire2Pressure = Double.Parse(carInfo[7]);
                int tire2Age = int.Parse(carInfo[8]);
                double tire3Pressure = Double.Parse(carInfo[9]);
                int tire3Age = int.Parse(carInfo[10]);
                double tire4Pressure = Double.Parse(carInfo[11]);
                int tire4Age = int.Parse(carInfo[12]);
                List<Tire> tires = new List<Tire>();
                tires.Add(new Tire(tire1Pressure, tire1Age));
                tires.Add(new Tire(tire2Pressure, tire2Age));
                tires.Add(new Tire(tire3Pressure, tire3Age));
                tires.Add(new Tire(tire4Pressure, tire4Age));
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Engine engine = new Engine(engineSpeed, enginePower);
                Car car = new Car(carModel, engine, cargo, tires);
                cars.Add(car);
            }
            string cargoArg = Console.ReadLine();
            switch (cargoArg)
            {
                case "flamable":
                    HashSet<string> modelCarForFlamableCargo = new HashSet<string>();
                    foreach (var car in cars)
                    {
                        if (car.engine.enginePower>250 && car.cargo.cargoType=="flamable")
                        {
                            modelCarForFlamableCargo.Add(car.model);
                        }                      
                    }
                    Console.WriteLine(string.Join("\n", modelCarForFlamableCargo));
                    break;
                case "fragile":
                    HashSet<string> modelCarForFragileCargo = new HashSet<string>();
                    foreach (var car in cars)
                    {
                        foreach (var tire in car.tires)
                        {
                            if (tire.presure < 1.0 && car.cargo.cargoType == "fragile")
                            {
                                modelCarForFragileCargo.Add(car.model);
                            }
                        }
                    }
                    Console.WriteLine(string.Join("\n", modelCarForFragileCargo));
                    break;
            }

        }
    }

    public class Car
    {
        public string model;
        public Engine engine;
        public Cargo cargo;
        public List<Tire> tires;

        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = new List<Tire>(tires);
        }
    }

    public class Engine
    {
        public int engineSpeed;
        public int enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }
    }

    public class Cargo
    {
        public string cargoType;
        public int cargoWeight;
        public Cargo(string cargoType, int cargoWeight)
        {
            this.cargoType = cargoType;
            this.cargoWeight = cargoWeight;
        }
    }

    public class Tire
    {
        public double presure;
        public int age;

        public Tire(double presure, int age)
        {
            this.presure = presure;
            this.age = age;
        }
    }
}

