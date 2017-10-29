using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex userName = new Regex(@"\b[a-zA-Z]\w{2,24}\b");
            MatchCollection matches = userName.Matches(input);

            int first = 0;
            int second = 1;
            int bestSum = int.MinValue;
            int sum = 0;

            for (int i = 0; i < matches.Count - 1; i++)
            {
                sum = matches[i].Length + matches[i + 1].Length;
                if (sum > bestSum)
                {
                    bestSum = sum;
                    first = i;
                    second = i + 1;
                }
            }
            Console.WriteLine(matches[first]);
            Console.WriteLine(matches[second]);
        }
    }
}
