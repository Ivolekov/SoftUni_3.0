using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Population_Counter
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                if (input == "report")
                {
                    break;
                }

                string[] tokens = input.Split('|');
                string country = tokens[1];
                string city = tokens[0];
                long population = long.Parse(tokens[2]);

                if (!data.ContainsKey(country))
                {
                    data[country] = new Dictionary<string, long>();

                    if (!data[country].ContainsKey(city))
                    {
                        data[country][city] = 0;
                    }
                    data[country][city] += population;
                }
                else
                {
                    data[country].Add(city, population);
                }

                input = Console.ReadLine();
            }

            var sortedPopulation = data.OrderByDescending(x => x.Value.Sum(y => y.Value));

            foreach (var item in sortedPopulation)
            {
                long totalPopulation = item.Value.Sum(x => x.Value);
                Console.WriteLine("{0} (total population: {1})", item.Key, totalPopulation);
                var sortedCityPopulation = item.Value.OrderByDescending(x => x.Value);
                foreach (var deepItem in sortedCityPopulation)
                {
                    Console.WriteLine("=>{0}: {1}", deepItem.Key, deepItem.Value);
                }
            }
        }
    }
}
