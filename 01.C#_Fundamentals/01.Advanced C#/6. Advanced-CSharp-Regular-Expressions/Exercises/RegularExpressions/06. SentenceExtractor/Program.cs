using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.SentenceExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string input = Console.ReadLine();
            Regex reg = new Regex(@"([A-Z][\w\W]*?\s)" + word + @"(\s[\W\w]*?[.!?])");
            MatchCollection matches = reg.Matches(input);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
