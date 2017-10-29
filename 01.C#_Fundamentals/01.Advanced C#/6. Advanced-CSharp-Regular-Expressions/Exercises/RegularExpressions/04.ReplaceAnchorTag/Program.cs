using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ReplaceAnchorTag
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
                string pattern = @"<a\s+href=([^>]+)>([^<]+)</a>";
                Regex regex = new Regex(pattern);
                string replacement = "[URL href=$1]$2[/URL]";
                string result = Regex.Replace(input, pattern, replacement);
                Console.WriteLine(result);

                input = Console.ReadLine();
            }

        }
    }
}
