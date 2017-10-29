using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractHyperlinks
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input !="END")
            {
                if (input == "END")
                {
                    break;
                }

                string pattern = @"(?:<a)(?:[\s\n_0-9a-zA-Z=""()]*?.*?)(?:href([\s\n]*)?=(?:['""\s\n]*)?)([a-zA-Z:#\/._\-0-9!?=^+]*(\([""'a-zA-Z\s.()0-9]*\))?)(?:[\s\na-zA-Z=""()0-9]*.*?)?(?:\>)";

                Regex reg = new Regex(pattern);
                MatchCollection matches = reg.Matches(input);
                foreach (Match item in matches)
                {
                    Console.WriteLine(item.Groups[2].Value);
                }

                input=Console.ReadLine();
            }
        }
    }
}
