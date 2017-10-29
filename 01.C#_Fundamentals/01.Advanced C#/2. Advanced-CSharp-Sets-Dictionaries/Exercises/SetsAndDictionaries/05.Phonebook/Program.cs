using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Phonebook
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>();


            while (input != "search")
            {
                string[] command = input.Split('-');
                string name = command[0];
                string phone = command[1];

                if (!dict.ContainsKey(name))
                {
                    dict[name] = null;
                }

                dict[name] = phone;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "stop")
            {
                if (dict.ContainsKey(input))
                {
                    Console.WriteLine("{0} -> {1}", input, dict[input]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
