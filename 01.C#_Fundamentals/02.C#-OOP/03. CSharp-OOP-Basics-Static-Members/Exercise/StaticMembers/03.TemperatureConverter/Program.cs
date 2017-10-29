using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TemperatureConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input!="End")
            {
                string[] tempereturArgs = input.Split();
                int tempereture = int.Parse(tempereturArgs[0]);
                switch (tempereturArgs[1])
                {
                    case "Celsius":
                        Console.WriteLine(TemperatureConverter.ConvertToF(tempereture) + " Fahrenheit");
                        break;
                    case "Fahrenheit":
                        Console.WriteLine(TemperatureConverter.ConvertToC(tempereture) + " Celsius");
                        break;  
                }
                input = Console.ReadLine();
            }
        }
    }

    public class TemperatureConverter
    {
        public static string ConvertToF(int tempereture)
        {
            double result = tempereture * 1.8 + 32;
            return string.Format($"{result:F2}");
        }
        public static string ConvertToC(int tempereture)
        {
            double result = (tempereture -32)/ 1.8;
            return string.Format($"{result:F2}");
        }
    }
}
