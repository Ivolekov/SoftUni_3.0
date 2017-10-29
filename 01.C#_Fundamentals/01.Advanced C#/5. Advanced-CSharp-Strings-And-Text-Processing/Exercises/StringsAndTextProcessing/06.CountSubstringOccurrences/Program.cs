using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string stringToFind = Console.ReadLine().ToLower();
            int possition = input.IndexOf(stringToFind);
            int foundString = 0;

            while (possition >= 0 && possition <= input.Length)
            {
                foundString++;
                possition = input.IndexOf(stringToFind, possition + 1);
            }

            Console.WriteLine(foundString);
        }
    }
}
