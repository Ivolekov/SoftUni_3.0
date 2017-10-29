using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int engineLines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < engineLines; i++)
            {
                string[] engineInput = Console.ReadLine().Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineInput[0];
                string enginePower = engineInput[1];
                Engine engine = new Engine(engineModel, enginePower);
                if (engineInput.Length > 3)
                {
                    engine.displacement = engineInput[2];
                    engine.efficiency = engineInput[3];
                }
                if (engineInput.Length > 2)
                {
                    int n;
                    bool isNumeric = int.TryParse(engineInput[2], out n);
                    if (isNumeric)
                    {
                        engine.displacement = engineInput[2];
                    }
                    else
                    {
                        engine.displacement = engineInput[2];
                    }
                }
                engines.Add(engine);
            }
            int carLines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < carLines; i++)
            {
                string[] carInput = Console.ReadLine().Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInput[0];
                string engineModel = carInput[1];
                Engine engine = engines.First(x => x.model == engineModel);
                Car car = new Car(carModel, engine);
                if (carInput.Length > 3)
                {
                    car.weight = carInput[2];
                    car.color = carInput[3];
                }
                if (carInput.Length > 2)
                {
                    int n;
                    bool isNumeric = int.TryParse(carInput[2], out n);
                    if (isNumeric)
                    {
                        car.weight = carInput[2];
                    }
                    else
                    {
                        car.color = carInput[2];
                    }
                }
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
            //Console.WriteLine();
        }
    }

    public class Car
    {
        public string model;
        public Engine engine;
        public string weight;
        public string color;

        public Car(string model, Engine engine, string weight, string color)
        {
            this.model = model;
            this.engine = engine;
            this.weight = weight;
            this.color = color;
        }
        public Car(string model, Engine engine) : this(model, engine, "n/a", "n/a")
        {
            this.model = model;
            this.engine = engine;
        }

        public override string ToString()
        {
            return string.Format("{0}:\n{1}\n  Weight: {2}\n  Color: {3}",this.model,this.engine,this.weight,this.color);
        }
    }

    public class Engine
    {
        public string model;
        public string power;
        public string displacement;
        public string efficiency;

        public Engine(string model, string power, string displacement, string efficiency)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public Engine(string model, string power) : this(model, power, "n/a", "n/a")
        {
            this.model = model;
            this.power = power;
        }

        public override string ToString()
        {
            return string.Format("  {0}:\n   Power: {1}\n   Displacement: {2}\n   Efficiency: {3}", 
                this.model, this.power, this.displacement, this.efficiency);

        }
    }
}
