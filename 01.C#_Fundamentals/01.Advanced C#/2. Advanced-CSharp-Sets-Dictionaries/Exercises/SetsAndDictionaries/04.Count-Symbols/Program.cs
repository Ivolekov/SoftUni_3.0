using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Count_Symbols
{
    public class Program
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();

            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (!dict.ContainsKey(current))
                {
                    dict[current] = 1;
                }
                else
                {
                    dict[current] += 1;
                }


            }

            foreach (var item in dict)
            {
                Console.WriteLine("{0}: {1} time/s", item.Key, item.Value);
            }

        }
    }
}
