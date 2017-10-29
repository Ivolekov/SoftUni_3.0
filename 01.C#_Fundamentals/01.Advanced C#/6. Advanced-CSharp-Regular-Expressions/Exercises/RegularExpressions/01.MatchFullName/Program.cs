using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "end")
                {
                    break;
                }

                string pattern = @"(?:[A-Z])[a-z]+\s(?:[A-Z])[a-z]+";
                Regex reg = new Regex(pattern);
                Match matches = reg.Match(input);
                Console.WriteLine(matches);

                input = Console.ReadLine();
            }
        }
    }
}
