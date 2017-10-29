using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Legendary_Farming
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            Dictionary<string, int> junks = new Dictionary<string, int>();

            data.Add("fragments", 0);
            data.Add("shards", 0);
            data.Add("motes", 0);
            bool isEnoughMaterials = false;

            while (!isEnoughMaterials)
            {
                string[] input = Console.ReadLine().ToLower().Split(' ').ToArray();

                for (int i = 0; i < input.Length; i+=2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];

                    if (data.ContainsKey(material))
                    {
                        data[material] += quantity;
                        if (data[material] >= 250)
                        {
                            data[material] -= 250;
                            isEnoughMaterials = true;
                            string obtained = string.Empty;
                            switch (material)
                            {
                                case "shards": obtained += "Shadowmourne"; break;
                                case "fragments": obtained += "Valanyr"; break;
                                case "motes": obtained += "Dragonwrath"; break;
                                default:
                                    break;
                            }
                            Console.WriteLine("{0} obtained!", obtained);
                            break;
                        }
                    }
                    else
                    {
                        if (!junks.ContainsKey(material))
                        {
                            junks[material] = 0;
                        }
                        junks[material] += quantity;
                    }
                    
                }
            }

            var sortedData = data.OrderByDescending(x => x.Value).ThenBy(y=>y.Key);

            foreach (var item in sortedData)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
            var sortedJunks = junks.OrderBy(x => x.Key);
            foreach (var item in sortedJunks)
            {
                 Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }
    }
}
