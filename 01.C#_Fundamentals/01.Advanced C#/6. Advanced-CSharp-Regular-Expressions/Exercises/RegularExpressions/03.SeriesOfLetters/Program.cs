using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.SeriesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var regex = new Regex("(.)\\1+");
            Console.WriteLine(regex.Replace(input, "$1"));
        }
    }
}
