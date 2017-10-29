using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BasicMath
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];
                double a = double.Parse(tokens[1]);
                double b = double.Parse(tokens[2]);

                switch (command)
                {
                    case "Sum":
                        MathUtil.Sum(a, b);
                        break;
                    case "Subtract":
                        MathUtil.Subtract(a, b);
                        break;
                    case "Multiply":
                        MathUtil.Multiply(a, b);
                        break;
                    case "Divide":
                        MathUtil.Divide(a, b);
                        break;
                    case "Percentage":
                        MathUtil.Percentage(a, b);
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }

    public class MathUtil
    {
        public static void Sum(double a, double b)
        {
            Console.WriteLine("{0:F2}", a + b);
        }

        public static void Subtract(double a, double b)
        {
            Console.WriteLine("{0:F2}", a - b);
        }

        public static void Multiply(double a, double b)
        {
            Console.WriteLine("{0:F2}", a * b);
        }

        public static void Divide(double a, double b)
        {
            Console.WriteLine("{0:F2}", a / b);
        }

        public static void Percentage(double a, double b)
        {
            Console.WriteLine("{0:F2}", (a * b) / 100);
        }
    }
}
