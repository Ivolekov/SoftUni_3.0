using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08.ShapesVolume
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();
                string shape = tokens[0];
                switch (shape)
                {
                    case "Cube":
                        VolumeCalculator.CalcCube(new Cube(double.Parse(tokens[1])));
                        break;
                    case "Cylinder":
                        VolumeCalculator.CalcCylinder(new Cylinder(double.Parse(tokens[1]), double.Parse(tokens[2])));
                        break;
                    case "TrianglePrism":
                        VolumeCalculator.CalcTriangularPrism(new TriangularPrism(double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3])));
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }

    public class TriangularPrism
    {
        public double side;
        public double height;
        public double lenght;

        public TriangularPrism(double side, double height, double lenght)
        {
            this.side = side;
            this.height = height;
            this.lenght = lenght;
        }
    }

    public class Cube
    {
        public double side;
        public Cube(double side)
        {
            this.side = side;
        }
    }

    public class Cylinder
    {
        public double radius;
        public double height;
        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }
    }

    public class VolumeCalculator
    {
        public Cube cube;
        public TriangularPrism triangularPrism;
        public Cylinder cylinder;

        public static void CalcCube(Cube cube)
        {
            var result = Math.Pow(cube.side, 3);
            Console.WriteLine("{0:F3}", result);
        }

        public static void CalcTriangularPrism(TriangularPrism triangularPrism)
        {
            var result = 0.5 * triangularPrism.side * triangularPrism.height * triangularPrism.lenght;
            Console.WriteLine("{0:F3}", result);
        }

        public static void CalcCylinder(Cylinder cylinder)
        {
            var result = Math.PI * Math.Pow(cylinder.radius, 2) * cylinder.height;
            Console.WriteLine("{0:F3}", result);
        }
    }
}
