using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Logs_Aggregator
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, int> dataUser = new SortedDictionary<string, int>();
            Dictionary<string, SortedSet<string>> dataIp = new Dictionary<string, SortedSet<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string ip = input[0];
                string name = input[1];
                int duration = int.Parse(input[2]);

                if (!dataUser.ContainsKey(name))
                {
                    dataUser.Add(name, 0);
                }
                dataUser[name] += duration;
                if (!dataIp.ContainsKey(name))
                {
                    dataIp.Add(name, new SortedSet<string>());
                }
                dataIp[name].Add(ip);
            }

            foreach (var item in dataUser)
            {
                Console.WriteLine("{0}: {1} [{2}]", item.Key, item.Value, string.Join(", ", dataIp[item.Key]));
            }
        }
    }
}
