using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.a_miner_task
{
    public class Program
    {
        public static void Main()
        {
            //string[] input = Console.ReadLine().Split();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            string resourse = Console.ReadLine();
            string quantity = Console.ReadLine();

            while (resourse != "stop")
            {
                if (!dict.ContainsKey(resourse))
                {
                    dict[resourse] = 0;
                }
                    dict[resourse] += int.Parse(quantity);
                
                resourse = Console.ReadLine();
                if (resourse == "stop")
                {
                    break;
                }
                quantity = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }

        }
    }
}
