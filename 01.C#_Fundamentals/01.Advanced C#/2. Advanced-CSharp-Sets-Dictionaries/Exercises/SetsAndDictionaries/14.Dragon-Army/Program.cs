using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _14.Dragon_Army
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, SortedDictionary<string, List<decimal>>> data = 
                new Dictionary<string, SortedDictionary<string, List<decimal>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string color = input[0];
                string name = input[1];
                if (input[2] == "null")
                {
                    input[2] = "45";
                }
                if (input[3] == "null")
                {
                    input[3] = "250";
                }
                if (input[4] == "null")
                {
                    input[4] = "10";
                }
                decimal damage = decimal.Parse(input[2]);
                decimal health = decimal.Parse(input[3]);
                decimal armor = decimal.Parse(input[4]);

                if (!data.ContainsKey(color))
                {
                    data[color] = new SortedDictionary<string, List<decimal>>();
                    data[color].Add(name, new List<decimal>());
                    data[color][name].Add(damage);
                    data[color][name].Add(health);
                    data[color][name].Add(armor);
                }
                else
                {
                    if (!data[color].ContainsKey(name))
                    {
                        data[color][name] = new List<decimal>();
                        data[color][name].Add(damage);
                        data[color][name].Add(health);
                        data[color][name].Add(armor);
                    }
                    else
                    {
                        data[color][name].Clear();

                        data[color][name].Add(damage);
                        data[color][name].Add(health);
                        data[color][name].Add(armor);
                    }
                }
            }

            foreach (var item in data)
            {
                decimal damage = item.Value.Sum(x => x.Value[0]) / item.Value.Count;
                decimal health = item.Value.Sum(x => x.Value[1]) / item.Value.Count;
                decimal armor = item.Value.Sum(x => x.Value[2]) / item.Value.Count;

                Console.WriteLine("{0}::({1:F2}/{2:F2}/{3:F2})", item.Key, damage, health, armor);
                
                foreach (var deepItem in item.Value)
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}", deepItem.Key, deepItem.Value[0], deepItem.Value[1], deepItem.Value[2]);
                }
            }
        }
    }
}
