using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input !="end")
            {
                if (input == "end")
                {
                    break;
                }

                string pattern = @"(\+\d{3}-\d{1}-\d{3}-\d{4}|\+\d{3} \d{1} \d{3} \d{4})";
                Regex reg = new Regex(pattern);
                Match match = reg.Match(input);
                Console.WriteLine(match);
                
                input = Console.ReadLine();
            }
        }
    }
}
