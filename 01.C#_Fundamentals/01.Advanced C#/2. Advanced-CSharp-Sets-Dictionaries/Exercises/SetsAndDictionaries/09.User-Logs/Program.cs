using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.User_Logs
{
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            SortedDictionary<string, Dictionary<string, int>> data = new SortedDictionary<string, Dictionary<string, int>>();

            while (input[0] != "end")
            {
                if (input[0] == "end")
                {
                    break;
                }

                string[] ipToken = input[0].Split('=');
                string ip = ipToken[1];
                string message = input[1];
                string[] userToken = input[2].Split('=');
                string user = userToken[1];

                if (!data.ContainsKey(user))
                {
                    data[user] = new Dictionary<string, int>();
                }
                if (!data[user].ContainsKey(ip))
                {
                    data[user].Add(ip, 0);
                }
                data[user][ip]++;

                input = Console.ReadLine().Split();
            }

            foreach (var item in data)
            {
                Console.WriteLine(item.Key + ":");
                List<string> resultArr = new List<string>();
                foreach (var deepitem in item.Value)
                {
                    string result = deepitem.Key + " => " + deepitem.Value;
                    resultArr.Add(result);
                }
                Console.Write(string.Join(", ", resultArr));
                Console.WriteLine('.');
            }
        }
    }
}
